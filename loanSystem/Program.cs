using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class LoanUser
{
    public int ID { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public double LoanAmount { get; set; }
    public double MonthlyPayment { get; set; }
    public string DateStart { get; set; }
    public string DateEnd { get; set; }
    public int TotalMonths { get; set; }
    public bool HasReceivedLoan { get; set; }
    public int QueuePosition { get; set; }
    public int MonthsPaid { get; set; }
    public double RemainingAmount { get; set; }
    public int MonthsRemaining { get; set; }
    public double ServiceFee { get; set; }   // 1% of loan
    public double TotalCollected { get; set; }   // monthly payments collected so far
}

class FundStatus
{
    public double TotalMonthlyCollected { get; set; }  // all payments received from all users
    public double TotalLoansDisbursed { get; set; }  // total money given out as loans
    public double TotalServiceFees { get; set; }  // 1% from each loan issued
    public double CurrentBoxBalance { get; set; }  // money available right now
    public double NextUserLoanNeeded { get; set; }  // how much the next user needs
    public bool CanCoverNextLoan { get; set; }  // can we give the loan now?
    public double ShortfallAmount { get; set; }  // how much we're missing
    public int MonthsUntilCoverage { get; set; }  // months to wait if we can't cover
    public string NextUserInQueue { get; set; }  // name of next waiting user
}

class Program
{
    static List<LoanUser> users = new List<LoanUser>();
    static string filePath = "C:\\Users\\Codeline\\Desktop\\Csharp_Fundamentals_Training\\loanSystem\\users.txt";
    const double MAX_LOAN = 20000;
    const double MONTHLY_PAYMENT = 200;
    const double SERVICE_FEE = 200;   // fixed fee per user

    // ══════════════════════════════════════════════════════
    //  FILE LOADING
    // ══════════════════════════════════════════════════════
    static void LoadUsersFromFile()
    {
        users.Clear();

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"\n  [!] File not found: {filePath}");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        int lineNum = 0;
        int idCounter = 1;
        int waitingQ = 1;

        foreach (string line in lines)
        {
            lineNum++;
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;

            string[] p = line.Split(',');
            if (p.Length != 5) { Console.WriteLine($"  [!] Skipping invalid line {lineNum}."); continue; }

            try
            {
                double loan = Math.Min(double.Parse(p[2].Trim()), MAX_LOAN);
                double monthly = MONTHLY_PAYMENT;

                DateTime start = ParseDate(p[4].Trim());
                int totMths = (int)(loan / monthly); // calculated: loan / 200
                DateTime firstPayment = start.AddMonths(1);
                DateTime today = DateTime.Today;

                int monthsPaid = 0;
                if (today >= firstPayment)
                    monthsPaid = Math.Min(
                        ((today.Year - firstPayment.Year) * 12 +
                          today.Month - firstPayment.Month) + 1,
                        totMths);

                double remaining = Math.Max(loan - (monthsPaid * monthly), 0);
                int mthsLeft = Math.Max(totMths - monthsPaid, 0);
                double totalCollected = monthsPaid * monthly;
                double serviceFee = 200;

                bool hasLoan;
                int qPos;
                if (idCounter == 1) { hasLoan = true; qPos = 0; }
                else { hasLoan = false; qPos = waitingQ++; }

                users.Add(new LoanUser
                {
                    ID = idCounter++,
                    UserName = p[0].Trim(),
                    PhoneNumber = p[1].Trim(),
                    LoanAmount = loan,
                    MonthlyPayment = monthly,
                    DateStart = p[4].Trim(),
                    DateEnd = start.AddMonths(totMths).ToString("MM/yyyy"),
                    TotalMonths = totMths,
                    HasReceivedLoan = hasLoan,
                    QueuePosition = qPos,
                    MonthsPaid = monthsPaid,
                    RemainingAmount = remaining,
                    MonthsRemaining = mthsLeft,
                    ServiceFee = serviceFee,
                    TotalCollected = totalCollected
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  [!] Skipping line {lineNum} — {ex.Message}");
            }
        }
    }

    static DateTime ParseDate(string s)
    {
        string[] parts = s.Split('/');
        return new DateTime(int.Parse(parts[1]), int.Parse(parts[0]), 1);
    }

    // ══════════════════════════════════════════════════════
    //  FUND CALCULATION
    // ══════════════════════════════════════════════════════
    static FundStatus CalculateFund()
    {
        // Total payments collected from ALL users (active + paid off)
        double totalCollected = users
            .Sum(u => u.TotalCollected);

        // Total money given out as loans
        double totalDisbursed = users
            .Where(u => u.HasReceivedLoan)
            .Sum(u => u.LoanAmount);

        // Total service fees earned (1% per loan issued)
        double totalServiceFees = users.Count * SERVICE_FEE;

        // Box balance = money collected back - money given out + service fees
        // Service fee is deducted from the loan at disbursement, so it stays in the box
        double boxBalance = totalCollected;

        // Next user in queue
        var nextUser = users
            .Where(u => !u.HasReceivedLoan)
            .OrderBy(u => u.QueuePosition)
            .FirstOrDefault();

        double nextLoanNeeded = nextUser?.LoanAmount ?? 0;
        bool canCover = nextUser != null && boxBalance >= nextLoanNeeded;
        double shortfall = canCover ? 0 : Math.Max(nextLoanNeeded - boxBalance, 0);

        // How many more months of payments needed to cover the shortfall?
        // Each month: all active loan users pay 200 OMR
        int activeUsers = users.Count(u => u.HasReceivedLoan && u.RemainingAmount > 0);
        double monthlyInflow = users.Count * MONTHLY_PAYMENT; // all users pay 200 every month
        int monthsUntilCoverage = 0;

        if (!canCover && nextUser != null && monthlyInflow > 0)
        {
            double projected = boxBalance;
            while (projected < nextLoanNeeded && monthsUntilCoverage < 999)
            {
                projected += monthlyInflow;
                monthsUntilCoverage++;
            }
        }

        return new FundStatus
        {
            TotalMonthlyCollected = totalCollected,
            TotalLoansDisbursed = totalDisbursed,
            TotalServiceFees = totalServiceFees,
            CurrentBoxBalance = boxBalance,
            NextUserLoanNeeded = nextLoanNeeded,
            CanCoverNextLoan = canCover,
            ShortfallAmount = shortfall,
            MonthsUntilCoverage = monthsUntilCoverage,
            NextUserInQueue = nextUser?.UserName ?? "None"
        };
    }

    // ══════════════════════════════════════════════════════
    //  DISPLAY HELPERS
    // ══════════════════════════════════════════════════════
    static void PrintTableHeader()
    {
        Console.WriteLine("\n" + new string('═', 130));
        Console.WriteLine(
            $"  {"ID",-4} {"Name",-15} {"Phone",-13} {"Loan",10} {"Monthly",9} " +
            $"{"Start",8} {"End",8} {"Paid Mths",10} {"Collected",11} {"Remaining",11} {"Mths Left",10} {"Status",-18} {"Queue",6}");
        Console.WriteLine(new string('─', 130));
    }

    static void PrintUserRow(LoanUser u)
    {
        string status = u.HasReceivedLoan
            ? (u.RemainingAmount == 0 ? "✔ Paid Off" : "✔ Active Loan")
            : "⏳ Waiting";
        string queue = u.HasReceivedLoan ? "  —" : $"#{u.QueuePosition}";

        if (u.HasReceivedLoan && u.RemainingAmount == 0) Console.ForegroundColor = ConsoleColor.Green;
        else if (u.HasReceivedLoan) Console.ForegroundColor = ConsoleColor.Cyan;
        else Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine(
            $"  {u.ID,-4} {u.UserName,-15} {u.PhoneNumber,-13} {u.LoanAmount,10:N2} {u.MonthlyPayment,9:N2} " +
            $"{u.DateStart,8} {u.DateEnd,8} {u.MonthsPaid,10} {u.TotalCollected,11:N2} {u.RemainingAmount,11:N2} {u.MonthsRemaining,10} {status,-18} {queue,6}");

        Console.ResetColor();
    }

    static void PrintTableFooter(List<LoanUser> list)
    {
        Console.WriteLine(new string('═', 130));
        Console.WriteLine($"  Total Records: {list.Count}");
        Console.WriteLine(new string('═', 130));
    }

    static void PrintBoxPanel(FundStatus f)
    {
        Console.WriteLine("\n  ╔══════════════════════════════════════════════════════╗");
        Console.WriteLine("  ║               💰  FUND BOX STATUS                   ║");
        Console.WriteLine("  ╠══════════════════════════════════════════════════════╣");
        Console.WriteLine($"  ║  Total Payments Collected   : {f.TotalMonthlyCollected,10:N2} OMR          ║");
        Console.WriteLine($"  ║  Total Loans Disbursed      : {f.TotalLoansDisbursed,10:N2} OMR          ║");
        Console.WriteLine($"  ║  Service Fees Earned        : {f.TotalServiceFees,10:N2} OMR          ║");
        Console.WriteLine("  ╠══════════════════════════════════════════════════════╣");

        // Box balance color
        Console.Write("  ║  ");
        Console.Write("Current Box Balance          : ");
        Console.ForegroundColor = f.CurrentBoxBalance >= 0 ? ConsoleColor.Green : ConsoleColor.Red;
        Console.Write($"{f.CurrentBoxBalance,10:N2} OMR");
        Console.ResetColor();
        Console.WriteLine("          ║");

        Console.WriteLine("  ╠══════════════════════════════════════════════════════╣");
        Console.WriteLine($"  ║  Next User in Queue         : {f.NextUserInQueue,-24}║");
        Console.WriteLine($"  ║  Loan Amount Needed         : {f.NextUserLoanNeeded,10:N2} OMR          ║");
        Console.WriteLine("  ╠══════════════════════════════════════════════════════╣");

        if (f.NextUserInQueue == "None")
        {
            Console.WriteLine("  ║  ℹ️  No users waiting in queue.                      ║");
        }
        else if (f.CanCoverNextLoan)
        {
            Console.Write("  ║  ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("  ✅ READY! Box can cover the next loan now!        ");
            Console.ResetColor();
            Console.WriteLine("║");
        }
        else
        {
            Console.Write("  ║  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"  ❌ SHORT by {f.ShortfallAmount,10:N2} OMR                       ");
            Console.ResetColor();
            Console.WriteLine("║");

            Console.Write("  ║  ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"  ⏳ Est. {f.MonthsUntilCoverage} month(s) until we can issue next loan  ");
            Console.ResetColor();
            Console.WriteLine("║");
        }

        Console.WriteLine("  ╚══════════════════════════════════════════════════════╝");
    }

    // ══════════════════════════════════════════════════════
    //  MENU OPTIONS
    // ══════════════════════════════════════════════════════
    static void DisplayAllUsers()
    {
        Console.Clear();
        Console.WriteLine("\n  ══ ALL USERS ══");
        if (users.Count == 0) { Console.WriteLine("\n  No users loaded."); return; }
        PrintTableHeader();
        foreach (var u in users) PrintUserRow(u);
        PrintTableFooter(users);
        PrintBoxPanel(CalculateFund());
    }

    static void DisplayActiveLoanUsers()
    {
        Console.Clear();
        Console.WriteLine("\n  ══ ACTIVE LOAN USERS ══");
        var list = users.Where(u => u.HasReceivedLoan && u.RemainingAmount > 0).ToList();
        if (list.Count == 0) { Console.WriteLine("\n  No active loan users."); return; }
        PrintTableHeader();
        foreach (var u in list) PrintUserRow(u);
        PrintTableFooter(list);
    }

    static void DisplayWaitingQueue()
    {
        Console.Clear();
        Console.WriteLine("\n  ══ WAITING QUEUE ══");
        var list = users.Where(u => !u.HasReceivedLoan).OrderBy(u => u.QueuePosition).ToList();
        if (list.Count == 0) { Console.WriteLine("\n  No users in waiting queue."); return; }
        PrintTableHeader();
        foreach (var u in list) PrintUserRow(u);
        PrintTableFooter(list);
    }

    static void DisplayPaidOffUsers()
    {
        Console.Clear();
        Console.WriteLine("\n  ══ FULLY PAID OFF USERS ══");
        var list = users.Where(u => u.HasReceivedLoan && u.RemainingAmount == 0).ToList();
        if (list.Count == 0) { Console.WriteLine("\n  No fully paid users yet."); return; }
        PrintTableHeader();
        foreach (var u in list) PrintUserRow(u);
        PrintTableFooter(list);
    }

    static void DisplayFundBox()
    {
        Console.Clear();
        Console.WriteLine("\n  ══ FUND BOX & SERVICE FEES ══");
        FundStatus f = CalculateFund();

        // Per-user contribution breakdown
        Console.WriteLine("\n  ── Per-User Breakdown ──\n");
        Console.WriteLine($"  {"Name",-15} {"Loan",10} {"Service Fee ",18} {"Paid So Far",13} {"Remaining",11}");
        Console.WriteLine(new string('─', 75));

        foreach (var u in users)  // was: users.Where(u => u.HasReceivedLoan)
        {
            Console.ForegroundColor = u.RemainingAmount == 0 ? ConsoleColor.Green : ConsoleColor.Cyan;
            Console.WriteLine($"  {u.UserName,-15} {u.LoanAmount,10:N2} {u.ServiceFee,18:N2} {u.TotalCollected,13:N2} {u.RemainingAmount,11:N2}");
            Console.ResetColor();
        }

        Console.WriteLine(new string('─', 75));
        Console.WriteLine(
            $"  {"TOTAL",-15} " +
            $"{users.Sum(u => u.LoanAmount),10:N2} " +           // was: .Where(HasReceivedLoan)
            $"{users.Sum(u => u.ServiceFee),18:N2} " +           // was: .Where(HasReceivedLoan)
            $"{users.Sum(u => u.TotalCollected),13:N2} " +       // was: .Where(HasReceivedLoan)
            $"{users.Sum(u => u.RemainingAmount),11:N2}");       // was: .Where(HasReceivedLoan)

        PrintBoxPanel(f);
    }

    static void ShowSummary()
    {
        Console.Clear();
        Console.WriteLine("\n  ══ FULL SUMMARY ══\n");
        if (users.Count == 0) { Console.WriteLine("  No users loaded."); return; }

        FundStatus f = CalculateFund();
        var active = users.Where(u => u.HasReceivedLoan && u.RemainingAmount > 0).ToList();
        var waiting = users.Where(u => !u.HasReceivedLoan).ToList();
        var paidOff = users.Where(u => u.HasReceivedLoan && u.RemainingAmount == 0).ToList();

        Console.WriteLine($"  Total Users              : {users.Count}");
        Console.WriteLine($"  ✔  Active Loans          : {active.Count}");
        Console.WriteLine($"  ✔  Paid Off              : {paidOff.Count}");
        Console.WriteLine($"  ⏳ Waiting Queue          : {waiting.Count}");
        Console.WriteLine();
        Console.WriteLine($"  Max Loan Allowed         : {MAX_LOAN:N2} OMR");
        Console.WriteLine($"  Fixed Monthly Payment    : {MONTHLY_PAYMENT:N2} OMR");
        Console.WriteLine($"  Service Fee Per User     : {SERVICE_FEE:N2} OMR");
        Console.WriteLine();

        if (active.Count > 0)
        {
            var top = active.OrderByDescending(u => u.RemainingAmount).First();
            Console.WriteLine($"  Highest Remaining Loan   : {top.UserName} — {top.RemainingAmount:N2} OMR");
        }
        if (waiting.Count > 0)
        {
            var next = waiting.OrderBy(u => u.QueuePosition).First();
            Console.WriteLine($"  Next in Queue            : {next.UserName} (Queue #{next.QueuePosition}) — Needs {next.LoanAmount:N2} OMR");
        }

        PrintBoxPanel(f);
    }

    static void SearchByName()
    {
        Console.Clear();
        Console.WriteLine("\n  ══ SEARCH BY NAME ══");
        Console.Write("\n  Enter name: ");
        string kw = Console.ReadLine().Trim().ToLower();
        var results = users.Where(u => u.UserName.ToLower().Contains(kw)).ToList();
        if (results.Count == 0) { Console.WriteLine($"\n  No users found for '{kw}'."); return; }
        PrintTableHeader();
        foreach (var u in results) PrintUserRow(u);
        PrintTableFooter(results);
    }

    static void SearchByPhone()
    {
        Console.Clear();
        Console.WriteLine("\n  ══ SEARCH BY PHONE ══");
        Console.Write("\n  Enter phone: ");
        string ph = Console.ReadLine().Trim();
        var results = users.Where(u => u.PhoneNumber.Contains(ph)).ToList();
        if (results.Count == 0) { Console.WriteLine($"\n  No users found for '{ph}'."); return; }
        PrintTableHeader();
        foreach (var u in results) PrintUserRow(u);
        PrintTableFooter(results);
    }

    static void ReloadFile()
    {
        Console.Clear();
        Console.WriteLine("\n  ══ RELOAD FILE ══");
        LoadUsersFromFile();
        Console.WriteLine($"\n  ✔ Reloaded. {users.Count} user(s) loaded.");
    }

    // ══════════════════════════════════════════════════════
    //  MENU
    // ══════════════════════════════════════════════════════
    static void ShowMenu()
    {
        FundStatus f = CalculateFund();

        // Quick status line at top
        Console.WriteLine("\n  ┌─────────────────────────────────────────────────────┐");
        Console.Write("  │  💰 Box: ");
        Console.ForegroundColor = f.CurrentBoxBalance >= 0 ? ConsoleColor.Green : ConsoleColor.Red;
        Console.Write($"{f.CurrentBoxBalance,10:N2} OMR");
        Console.ResetColor();
        Console.Write($"  │  🏦 Fees: {f.TotalServiceFees,8:N2} OMR");

        if (f.NextUserInQueue != "None")
        {
            Console.Write("  │  Next: ");
            Console.ForegroundColor = f.CanCoverNextLoan ? ConsoleColor.Green : ConsoleColor.Yellow;
            Console.Write(f.CanCoverNextLoan ? "✅ READY" : $"⏳ {f.MonthsUntilCoverage} mth(s)");
            Console.ResetColor();
        }
        Console.WriteLine("\n  └─────────────────────────────────────────────────────┘");

        Console.WriteLine("  ╔═══════════════════════════════════════╗");
        Console.WriteLine("  ║       LOAN MANAGEMENT SYSTEM          ║");
        Console.WriteLine("  ╠═══════════════════════════════════════╣");
        Console.WriteLine("  ║  1. Display All Users                 ║");
        Console.WriteLine("  ║  2. Active Loan Users                 ║");
        Console.WriteLine("  ║  3. Waiting Queue                     ║");
        Console.WriteLine("  ║  4. Fully Paid Off Users              ║");
        Console.WriteLine("  ║  5. Fund Box & Service Fees           ║");
        Console.WriteLine("  ║  6. Search by Name                    ║");
        Console.WriteLine("  ║  7. Search by Phone                   ║");
        Console.WriteLine("  ║  8. Summary                           ║");
        Console.WriteLine("  ║  9. Reload File                       ║");
        Console.WriteLine("  ║  0. Exit                              ║");
        Console.WriteLine("  ╚═══════════════════════════════════════╝");
        Console.Write("\n  Select an option: ");
    }

    // ══════════════════════════════════════════════════════
    //  MAIN
    // ══════════════════════════════════════════════════════
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        LoadUsersFromFile();
        Console.WriteLine($"\n  ✔ {users.Count} user(s) loaded. Max loan: {MAX_LOAN:N2} OMR | Monthly: {MONTHLY_PAYMENT:N2} OMR | Fee: {SERVICE_FEE:N2} OMR");

        bool running = true;

        while (running)
        {
            ShowMenu();
            string input = Console.ReadLine()?.Trim();

            switch (input)
            {
                case "1": DisplayAllUsers(); break;
                case "2": DisplayActiveLoanUsers(); break;
                case "3": DisplayWaitingQueue(); break;
                case "4": DisplayPaidOffUsers(); break;
                case "5": DisplayFundBox(); break;
                case "6": SearchByName(); break;
                case "7": SearchByPhone(); break;
                case "8": ShowSummary(); break;
                case "9": ReloadFile(); break;
                case "0":
                    Console.Clear();
                    Console.WriteLine("\n  Goodbye! Exiting system...\n");
                    running = false;
                    break;
                default:
                    Console.WriteLine("\n  [!] Invalid option. Choose 0–9.");
                    break;
            }

            if (running)
            {
                Console.Write("\n  Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}