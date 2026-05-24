namespace SystemStorage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ── REGION 1: System Storage ─────────────────────────────────────

            // Capacity constants

            const int MAX_PATIENTS = 3;
            const int MAX_DOCTORS = 2;
            const int MAX_APPOINTMENTS = 3;

            // Patient slots
            string p1Name = ""; int p1Age = 0; string p1Phone = ""; bool p1Active = false;

            string p2Name = ""; int p2Age = 0; string p2Phone = ""; bool p2Active = false;

            string p3Name = ""; int p3Age = 0; string p3Phone = ""; bool p3Active = false;

            int patientCount = 0;


            // Doctor slots
            string d1Name = ""; string d1Spec = ""; double d1Fee = 0; bool d1Active = false;

            string d2Name = ""; string d2Spec = ""; double d2Fee = 0; bool d2Active = false;

            int doctorCount = 0;


            // Appointment slots
            string a1Patient = ""; string a1Doctor = ""; string a1Date = ""; string a1Status = ""; bool a1Active = false;

            string a2Patient = ""; string a2Doctor = ""; string a2Date = ""; string a2Status = ""; bool a2Active = false;

            string a3Patient = ""; string a3Doctor = ""; string a3Date = ""; string a3Status = ""; bool a3Active = false;

            int appointmentCount = 0;

            bool exit = true;
            char main;
            bool sub_exit = true;
            char sub_main;
            int displayNum;
            string targetP;
            int patientChoice;
            string chosenPatient = "";
            int patientCounter = 0;
            int doctorChoice;
            string chosendoctor = "";
            int doctorCounter = 0;
            string date;
            int slot;
            char statuschoice;
            do
            {
                Console.WriteLine("");
                Console.WriteLine(@"╔══════════════════════════════════════╗
║ CLINIC MANAGEMENT SYSTEM             ║
╠══════════════════════════════════════╣
║ 1. Patient Management                ║
║ 2. Doctor Management                 ║
║ 3. Appointment Management            ║
║ 0. Exit                              ║
╚══════════════════════════════════════╝");

                Console.WriteLine("");
                Console.Write("Enter Your Choice: ");
                main = Convert.ToChar(Console.ReadLine());

                Console.Clear();

                switch (main)
                {
                    case '0':
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("Shutting Down..");
                        exit = false;
                        break;

                    case '1':

                        do
                        {

                            Console.WriteLine(@"╔══════════════════════════════════════╗
║ PATIENT MANAGEMENT                   ║
╠══════════════════════════════════════╣
║ 1. Add New Patient                   ║
║ 2. Display All Patients              ║
║ 3. Update Patient Phone              ║
║ 4. Delete Patient                    ║
║ 0. Back to Main Menu                 ║
╚══════════════════════════════════════╝");

                            Console.WriteLine("");
                            Console.Write("Enter Your Choice: ");
                            sub_main = Convert.ToChar(Console.ReadLine());

                            Console.Clear();

                            switch (sub_main)
                            {
                                case '0':
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    Console.WriteLine("Returnning To CLINIC MANAGEMENT SYSTEM..");
                                    sub_exit = false;
                                    break;

                                case '1':

                                    if (patientCount == MAX_PATIENTS)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Clinic is Full. Cannot Add More Patients");
                                        break;
                                    }

                                    else
                                    {
                                        if (!p1Active)
                                        {
                                            Console.WriteLine();
                                            Console.Write("Enter The Patient Name : ");
                                            p1Name = Console.ReadLine();
                                            if (p1Name == null)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Error.. The Name Most Not Be Empty.");
                                                break;
                                            }

                                            Console.WriteLine();
                                            Console.Write("Enter The Patient Age  : ");
                                            p1Age = Convert.ToInt32(Console.ReadLine());
                                            if (p1Age < 1 || p1Age > 120)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Error..");
                                            }

                                            Console.WriteLine();
                                            Console.Write("Enter The Patient Phone : ");
                                            p1Phone = Console.ReadLine();
                                            p1Active = true;
                                            patientCount++;

                                        }


                                        else if (!p2Active)
                                        {
                                            Console.WriteLine();
                                            Console.Write("Enter The Patient Name: ");
                                            p2Name = Console.ReadLine();
                                            if (p2Name == null)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Error.. The Name Most Not Be Empty.");
                                                break;
                                            }

                                            Console.WriteLine();
                                            Console.Write("Enter The Patient Age  : ");
                                            p2Age = Convert.ToInt32(Console.ReadLine());
                                            if (p2Age < 1 || p2Age > 120)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Error..");
                                            }

                                            Console.WriteLine();
                                            Console.Write("Enter The Patient Phone: ");
                                            p2Phone = Console.ReadLine();
                                            p2Active = true;

                                        }


                                        else if (!p3Active)
                                        {
                                            Console.WriteLine();
                                            Console.Write("Enter The Patient Name: ");
                                            p3Name = Console.ReadLine();
                                            if (p3Name == null)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Error.. The Name Most Not Be Empty.");
                                                break;
                                            }

                                            Console.WriteLine();
                                            Console.Write("Enter The Patient Age  : ");
                                            p3Age = Convert.ToInt32(Console.ReadLine());
                                            if (p3Age < 1 || p3Age > 120)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Error..");
                                            }

                                            Console.WriteLine();
                                            Console.Write("Enter The Patient Phone: ");
                                            p3Phone = Console.ReadLine();
                                            p3Active = true;

                                        }
                                    }
                                    break;

                                case '2':

                                    displayNum = 1;

                                    if (patientCount == 0)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("No Patient Registered.");
                                        Console.WriteLine("");
                                    }
                                    else
                                    {
                                        if (p1Active)
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("Patient No " + displayNum);
                                            Console.WriteLine("");
                                            Console.WriteLine("Patient Name :    " + p1Name);
                                            Console.WriteLine("Patient Age  :    " + p1Age);
                                            Console.WriteLine("Patient Phone:    " + p1Phone);
                                            Console.WriteLine("");
                                            displayNum++;
                                        }

                                        if (p2Active)
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("Patient No " + displayNum);
                                            Console.WriteLine("");
                                            Console.WriteLine("Patient Name :    " + p2Name);
                                            Console.WriteLine("Patient Age  :    " + p2Age);
                                            Console.WriteLine("Patient Phone:    " + p2Phone);
                                            Console.WriteLine("");
                                            displayNum++;
                                        }

                                        if (p3Active)
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("Patient No " + displayNum);
                                            Console.WriteLine("");
                                            Console.WriteLine("Patient Name :    " + p3Name);
                                            Console.WriteLine("Patient Age  :    " + p3Age);
                                            Console.WriteLine("Patient Phone:    " + p3Phone);
                                            Console.WriteLine("");
                                            displayNum++;
                                        }

                                    }
                                    break;

                                case '3':

                                    Console.WriteLine();
                                    Console.Write("Enter Patient Name: ");
                                    targetP = Console.ReadLine();

                                    if (p1Active && targetP == p1Name)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Enter Patient Phone: ");
                                        p1Phone = Console.ReadLine();
                                        Console.WriteLine("Updated.");
                                    }
                                    else if (p2Active && targetP == p2Name)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Enter Patient Phone: ");
                                        p2Phone = Console.ReadLine();
                                        Console.WriteLine("Updated.");
                                    }
                                    else if (p3Active && targetP == p3Name)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Enter Patient Phone: ");
                                        p2Phone = Console.ReadLine();
                                        Console.WriteLine("Updated.");
                                    }
                                    else
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Patient Not Found.");
                                    }

                                    break;

                                case '4':

                                    Console.WriteLine();
                                    Console.Write("Enter Patient Name: ");
                                    targetP = Console.ReadLine();

                                    if (p1Active && targetP == p1Name)
                                    {
                                        p1Name = "";
                                        p1Age = 0;
                                        p1Phone = "";
                                        p1Active = false;
                                        patientCount--;

                                        Console.WriteLine();
                                        Console.WriteLine("Patient Deleted.");
                                    }
                                    else if (p2Active && targetP == p2Name)
                                    {
                                        p2Name = "";
                                        p2Age = 0;
                                        p2Phone = "";
                                        p2Active = false;
                                        patientCount--;

                                        Console.WriteLine();
                                        Console.WriteLine("Patient Deleted.");
                                    }
                                    else if (p3Active && targetP == p3Name)
                                    {
                                        p3Name = "";
                                        p3Age = 0;
                                        p3Phone = "";
                                        p3Active = false;
                                        patientCount--;

                                        Console.WriteLine();
                                        Console.WriteLine("Patient Deleted.");
                                    }
                                    else
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Patient Not Found.");
                                    }
                                    break;
                            }
                        } while (sub_exit);
                        break;

                    case '2':
                     
                        do
                        {

                            Console.WriteLine(@"╔══════════════════════════════════════╗
║ DOCTOR MANAGEMENT                    ║
╠══════════════════════════════════════╣
║ 1. Add New Doctor                    ║
║ 2. Display All Doctors               ║
║ 3. Update Consultation Fee           ║
║ 4. Delete Doctor                     ║
║ 0. Back to Main Menu                 ║
╚══════════════════════════════════════╝");

                            Console.WriteLine("");
                            Console.Write("Enter Your Choice: ");
                            sub_main = Convert.ToChar(Console.ReadLine());

                            Console.Clear();

                            switch (sub_main)
                            {
                                case '0':
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    Console.WriteLine("Returnning To CLINIC MANAGEMENT SYSTEM..");
                                    sub_exit = false;
                                    break;

                                case '1':

                                    if (doctorCount == MAX_DOCTORS)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("No Avalibale Doctor Slots");
                                        break;
                                    }
                                    else
                                    {
                                        if (!d1Active)
                                        {
                                            Console.WriteLine();
                                            Console.Write("Enter The Doctor Name : ");
                                            d1Name = Console.ReadLine();
                                            if (d1Name == null)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Error.. The Name Most Not Be Empty.");
                                                break;
                                            }

                                            Console.WriteLine();
                                            Console.Write("Enter The Specialization  : ");
                                            d1Spec = Console.ReadLine();
                                            if (d1Spec == null)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Error..");
                                            }

                                            Console.WriteLine();
                                            Console.Write("Enter The Doctor Fee : ");
                                            d1Fee = Convert.ToDouble(Console.ReadLine());
                                            doctorCount++;
                                            d1Active = true;
                                        }


                                        else if (!d2Active)
                                        {
                                            Console.WriteLine();
                                            Console.Write("Enter The Doctor Name : ");
                                            d2Name = Console.ReadLine();
                                            if (d2Name == null)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Error.. The Name Most Not Be Empty.");
                                                break;
                                            }

                                            Console.WriteLine();
                                            Console.Write("Enter The Specialization  : ");
                                            d2Spec = Console.ReadLine();
                                            if (d2Spec == null)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Error..");
                                            }

                                            Console.WriteLine();
                                            Console.Write("Enter The Doctor Fee : ");
                                            d2Fee = Convert.ToDouble(Console.ReadLine());
                                            d2Active = true;
                                            doctorCount++;
                                        }
                                    }
                                    break;

                                case '2':

                                    displayNum = 1;

                                    if (doctorCount == 0)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("No Doctors Registered.");
                                        Console.WriteLine("");
                                    }

                                    if (d1Active)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Doctor No " + displayNum);
                                        Console.WriteLine("");
                                        Console.WriteLine("Doctor Name              :    " + d1Name);
                                        Console.WriteLine("Doctor Specialization    :    " + d1Spec);
                                        Console.WriteLine("Doctor Fee               :    " + d1Fee);
                                        Console.WriteLine("");
                                        displayNum++;
                                    }

                                    if (d2Active)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Doctor No " + displayNum);
                                        Console.WriteLine("");
                                        Console.WriteLine("Doctor Name              :    " + d2Name);
                                        Console.WriteLine("Doctor Specialization    :    " + d2Spec);
                                        Console.WriteLine("Doctor Fee               :    " + d2Fee);
                                        Console.WriteLine("");
                                        displayNum++;
                                    }

                                    break;

                                case '3':

                                    Console.WriteLine();
                                    Console.Write("Enter Doctor Name: ");
                                    targetP = Console.ReadLine();

                                    if (d1Active && targetP == d1Name)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Enter Doctor Fee: ");
                                        d1Fee = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("Updated.");
                                    }
                                    else if (d2Active && targetP == d2Name)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Enter Doctor Fee: ");
                                        d2Fee = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("Updated.");
                                    }
                                    else
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Patient Not Found.");
                                    }

                                    break;

                                case '4':

                                    Console.WriteLine();
                                    Console.Write("Enter Doctor Name: ");
                                    targetP = Console.ReadLine();

                                    if (d1Active && targetP == d1Name)
                                    {

                                        d1Name = "";
                                        d1Spec = "";
                                        d1Fee = 0.0;
                                        d1Active = false;
                                        doctorCount--;

                                        Console.WriteLine();
                                        Console.WriteLine("Doctor Deleted.");
                                    }
                                    else if (d2Active && targetP == d2Name)
                                    {
                                        d2Name = "";
                                        d2Spec = "";
                                        d2Fee = 0.0;
                                        d2Active = false;
                                        doctorCount--;

                                        Console.WriteLine();
                                        Console.WriteLine("Doctor Deleted.");
                                    }
                                    else
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Doctor Not Found.");
                                    }
                                    break;
                            }
                        } while (sub_exit);
                        break;

                    case '3':

                        do
                        {
                            Console.WriteLine(@"╔══════════════════════════════════════╗
║ APPOINTMENT MANAGEMENT               ║
╠══════════════════════════════════════╣
║ 1. Book New Appointment              ║
║ 2. Display All Appointments          ║
║ 3. Update Appointment Status         ║
║ 4. Cancel Appointment                ║
║ 0. Back to Main Menu                 ║
╚══════════════════════════════════════╝");

                            Console.WriteLine("");
                            Console.Write("Enter Your Choice: ");
                            sub_main = Convert.ToChar(Console.ReadLine());

                            Console.Clear();

                            switch (sub_main)
                            {
                                case '0':
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    Console.WriteLine("Returnning To CLINIC MANAGEMENT SYSTEM..");
                                    sub_exit = false;
                                    break;
                                case '1':
                                    
                                    if (appointmentCount == MAX_APPOINTMENTS)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("No Avalible Appointment Slots");
                                        break;
                                    }
                                    else if (patientCount == 0 || doctorCount == 0)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Please Add Patients And Doctors First.");
                                        break;
                                    }
                                    else
                                    {
                                        patientCounter = 0;
                                        chosenPatient = "";
                                        doctorCounter = 0;
                                        chosendoctor = "";
                                        displayNum = 1;

                                        if (p1Active)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(displayNum + ".   " + p1Name);
                                            displayNum++;
                                        }
                                        if (p2Active)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(displayNum + ".   " + p2Name);
                                            displayNum++;
                                        }
                                        if (p3Active)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(displayNum + ".   " + p3Name);
                                            displayNum++;
                                        }

                                        Console.WriteLine();
                                        Console.Write("Enter Patient No.");

                                        patientChoice = Convert.ToInt32(Console.ReadLine());

                                        if (p1Active) 
                                        { 
                                            patientCounter++; 
                                            if (patientChoice == patientCounter)
                                            {
                                                chosenPatient = p1Name;
                                            }
                                        }
                                        if (p2Active)
                                        {
                                            patientCounter++;
                                            if (patientChoice == patientCounter)
                                            {
                                                chosenPatient = p2Name;
                                            }
                                        }
                                        if (p3Active)
                                        {
                                            patientCounter++;
                                            if (patientChoice == patientCounter)
                                            {
                                                chosenPatient = p3Name;
                                            }
                                        }
                                        if (chosenPatient == "")
                                        {
                                            Console.WriteLine("Invalid Patient Choice.");
                                            break;
                                        }

                                        //========================================================================================================

                                        displayNum = 1;

                                        if (d1Active)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(displayNum + ".   " + d1Name);
                                            displayNum++;
                                        }
                                        if (d2Active)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(displayNum + ".   " + d2Name);
                                            displayNum++;
                                        }

                                        Console.WriteLine();
                                        Console.Write("Enter Doctor No.");

                                        doctorChoice = Convert.ToInt32(Console.ReadLine());

                                        if (d1Active)
                                        {
                                            doctorCounter++;
                                            if (doctorChoice == doctorCounter)
                                            {
                                                chosendoctor = d1Name;
                                            }
                                        }
                                        if (d2Active)
                                        {
                                            doctorCounter++;
                                            if (doctorChoice == doctorCounter)
                                            {
                                                chosendoctor = d2Name;
                                            }
                                        }
                                        if (chosendoctor == "")
                                        {
                                            Console.WriteLine("Invalid Doctor Choice.");
                                            break;
                                        }

                                        Console.WriteLine();
                                        Console.Write("Enter Appointment Date.");

                                        date = Console.ReadLine();

                                        if (a1Active && a1Patient == chosenPatient && a1Doctor == chosendoctor && a1Date == date)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("Duplicate Appointment");
                                            break;
                                        }
                                        else if (a2Active && a2Patient == chosenPatient && a2Doctor == chosendoctor && a2Date == date)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("Duplicate Appointment");
                                            break;
                                        }
                                        else if (a3Active && a3Patient == chosenPatient && a3Doctor == chosendoctor && a3Date == date)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("Duplicate Appointment");
                                            break;
                                        }

                                        if (!a1Active)
                                        {
                                            a1Patient = chosenPatient;
                                            a1Doctor = chosendoctor;
                                            a1Date = date;
                                            a1Status = "Scheduled";
                                            a1Active = true;
                                            appointmentCount++;

                                            Console.WriteLine();
                                            Console.WriteLine("Appointment Booked");
                                        }
                                        else if (!a2Active)
                                        {
                                            a2Patient = chosenPatient;
                                            a2Doctor = chosendoctor;
                                            a2Date = date;
                                            a2Status = "Scheduled";
                                            a2Active = true;
                                            appointmentCount++;

                                            Console.WriteLine();
                                            Console.WriteLine("Appointment Booked");
                                        }
                                        else if (!a3Active)
                                        {
                                            a3Patient = chosenPatient;
                                            a3Doctor = chosendoctor;
                                            a3Date = date;
                                            a3Status = "Scheduled";
                                            a3Active = true;
                                            appointmentCount++;

                                            Console.WriteLine();
                                            Console.WriteLine("Appointment Booked");
                                        }
                                    }
                                    break;
                                case '2':

                                    if (appointmentCount == 0)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("No Appointments Booked");
                                        break;
                                    }
                                    else
                                    {
                                        displayNum = 1;

                                        if (a1Active)
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("Appointment No. " + displayNum);
                                            Console.WriteLine("");
                                            Console.WriteLine("Patient Name         :    " + a1Patient);
                                            Console.WriteLine("Doctor Name          :    " + a1Doctor);
                                            Console.WriteLine("Appointment Date     :    " + a1Date);
                                            Console.WriteLine("Appointment Satuts   :    " + a1Status);
                                            Console.WriteLine("");
                                            displayNum++;
                                        }
                                        if (a2Active)
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("Appointment No. " + displayNum);
                                            Console.WriteLine("");
                                            Console.WriteLine("Patient Name         :    " + a2Patient);
                                            Console.WriteLine("Doctor Name          :    " + a2Doctor);
                                            Console.WriteLine("Appointment Date     :    " + a2Date);
                                            Console.WriteLine("Appointment Satuts   :    " + a2Status);
                                            Console.WriteLine("");
                                            displayNum++;
                                        }
                                        if (a3Active)
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("Appointment No. " + displayNum);
                                            Console.WriteLine("");
                                            Console.WriteLine("Patient Name         :    " + a3Patient);
                                            Console.WriteLine("Doctor Name          :    " + a3Doctor);
                                            Console.WriteLine("Appointment Date     :    " + a3Date);
                                            Console.WriteLine("Appointment Satuts   :    " + a3Status);
                                            Console.WriteLine("");
                                            displayNum++;
                                        }
                                    }
                                    break;
                                case '3':

                                    if (appointmentCount == 0)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("No appointments booked.");
                                        break;
                                    }

                                    if (a1Active)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Slot No 1");
                                        Console.WriteLine("");
                                        Console.WriteLine("Patient Name         :    " + a1Patient);
                                        Console.WriteLine("Doctor Name          :    " + a1Doctor);
                                        Console.WriteLine("Appointment Date     :    " + a1Date);
                                        Console.WriteLine("Appointment Satuts   :    " + a1Status);
                                        Console.WriteLine("");
                                    }
                                    if (a2Active)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Slot No 2");
                                        Console.WriteLine("");
                                        Console.WriteLine("Patient Name         :    " + a2Patient);
                                        Console.WriteLine("Doctor Name          :    " + a2Doctor);
                                        Console.WriteLine("Appointment Date     :    " + a2Date);
                                        Console.WriteLine("Appointment Satuts   :    " + a2Status);
                                        Console.WriteLine("");
                                    }
                                    if (a3Active)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Slot No 3");
                                        Console.WriteLine("");
                                        Console.WriteLine("Patient Name         :    " + a3Patient);
                                        Console.WriteLine("Doctor Name          :    " + a3Doctor);
                                        Console.WriteLine("Appointment Date     :    " + a3Date);
                                        Console.WriteLine("Appointment Satuts   :    " + a3Status);
                                        Console.WriteLine("");
                                    }

                                    Console.WriteLine();
                                    Console.Write("Which Slot Want To Update?");
                                    slot = Convert.ToInt32 (Console.ReadLine());

                                    switch (slot)
                                    {
                                        case 1:
                                            Console.WriteLine();
                                            Console.WriteLine("Status Options:");
                                            Console.WriteLine("1. Scheduled");
                                            Console.WriteLine("2. Completed");
                                            Console.WriteLine("3. Cancelled");
                                            Console.WriteLine();

                                            statuschoice = Convert.ToChar(Console.ReadLine());

                                            if (statuschoice == '1')
                                            {
                                                a1Status = "Scheduled";
                                            }
                                            else if (statuschoice == '2')
                                            {
                                                a1Status = "Completed";
                                            }
                                            else if (statuschoice == '3')
                                            {
                                                a1Status = "Cancelled";
                                            }
                                            else
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Invalid Option");
                                            }

                                            break;

                                        case 2:
                                            Console.WriteLine();
                                            Console.WriteLine("Status Options:");
                                            Console.WriteLine("1. Scheduled");
                                            Console.WriteLine("2. Completed");
                                            Console.WriteLine("3. Cancelled");
                                            Console.WriteLine();

                                            statuschoice = Convert.ToChar(Console.ReadLine());

                                            if (statuschoice == '1')
                                            {
                                                a2Status = "Scheduled";
                                            }
                                            else if (statuschoice == '2')
                                            {
                                                a2Status = "Completed";
                                            }
                                            else if (statuschoice == '3')
                                            {
                                                a2Status = "Cancelled";
                                            }
                                            else
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Invalid Option");
                                            }
                                            break;

                                        case 3:
                                            Console.WriteLine();
                                            Console.WriteLine("Status Options:");
                                            Console.WriteLine("1. Scheduled");
                                            Console.WriteLine("2. Completed");
                                            Console.WriteLine("3. Cancelled");
                                            Console.WriteLine();

                                            statuschoice = Convert.ToChar(Console.ReadLine());

                                            if (statuschoice == '1')
                                            {
                                                a3Status = "Scheduled";
                                            }
                                            else if (statuschoice == '2')
                                            {
                                                a3Status = "Completed";
                                            }
                                            else if (statuschoice == '3')
                                            {
                                                a3Status = "Cancelled";
                                            }
                                            else
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Invalid Option");
                                            }
                                            break;

                                        default:
                                            Console.WriteLine();
                                            Console.WriteLine("Invalid Slot");
                                            break;
                                    }

                                    break;
                                case '4':

                                    Console.WriteLine();
                                    Console.Write("Enter Patient Name       : ");
                                    targetP = Console.ReadLine();

                                    Console.WriteLine();
                                    Console.Write("Enter Appointment Date   : ");
                                    date = Console.ReadLine();

                                    if (a1Active && a1Patient == targetP && a1Date == date)
                                    {
                                        a1Status = "Cancelled";
                                    }
                                    else if (a2Active && a2Patient == targetP && a2Date == date)
                                    {
                                        a2Status = "Cancelled";
                                    }
                                    else if (a3Active && a3Patient == targetP && a3Date == date)
                                    {
                                        a3Status = "Cancelled";
                                    }
                                    else
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Appointment Not Found.");
                                    }

                                    break;
                            }

                        } while (sub_exit);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Option.");
                        Console.WriteLine("");
                        break;
                }
            } while (exit);
        }
    }
}
