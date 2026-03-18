
using System.Runtime.CompilerServices;

public class Program
{
    public static void Main(string[] args)
    {

        Database database = new Database();

        while(true)
        {

            Console.WriteLine("[?] What would you like to do?");
            Console.WriteLine("------------------------------");
            Console.WriteLine("[1] Add Owner");
            Console.WriteLine("[2] Change Phone Number");
            Console.WriteLine("[3] View All");
            Console.WriteLine("[4] Add Pet");
            Console.WriteLine("[5] Find owner phone number with pet name");
            
            string MainInput = Console.ReadLine();

            if(MainInput == "1")
            {

                int IDInput;
                string NameInput;
                int PhoneNumberInput;

                Console.WriteLine("[?] Provide an ID for the owner. (Int, MUST be unique)");

                while(true)
                {

                    string Input1 = Console.ReadLine();

                    var ValidInput = int.TryParse(Input1, out int n);

                    if(ValidInput == true)
                    {

                        int ConvertedInput = Convert.ToInt32(Input1);

                        bool UniqueInput = database.IDIsUnique(ConvertedInput);

                        if(UniqueInput == true)
                        {
                            IDInput = Convert.ToInt32(Input1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("[!] Input not unique!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("[!] Invalid Input!");
                    }

                }

                Console.WriteLine("[?] Provide a name for the owner.");

                while(true)
                {

                    string Input2 = Console.ReadLine();

                    if(Input2 != "")
                    {
                        NameInput = Input2;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("[!] Invalid Input!");
                    }

                }

                Console.WriteLine("[?] Provide a phone number for the owner. (Int, MUST be unique)");

                while(true)
                {

                    string Input3 = Console.ReadLine();

                    var ValidInput = int.TryParse(Input3, out int n);

                    if(ValidInput == true)
                    {
                        
                        int ConvertedInput = Convert.ToInt32(Input3);

                        bool UniqueInput = database.PhoneNumberIsUnique(ConvertedInput);

                        if(UniqueInput == true)
                        {
                            PhoneNumberInput = Convert.ToInt32(Input3);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("[!] Input not unique!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("[!] Invalid Input!");
                    }

                }

                database.AddOwner(IDInput, NameInput, PhoneNumberInput);

            }
            else if(MainInput == "2")
            {

                int IDInput;
                int PhoneNumberInput;

                Console.WriteLine("[?] Provide the ID of the owner.");

                while(true)
                {

                    string Input1 = Console.ReadLine();

                    var ValidInput = int.TryParse(Input1, out int n);

                    if(ValidInput == true)
                    {

                        int ConvertedInput = Convert.ToInt32(Input1);

                        bool UniqueInput = database.IDIsUnique(ConvertedInput);

                        if(UniqueInput == false)
                        {
                            IDInput = Convert.ToInt32(Input1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("[!] ID doesn't exist!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("[!] Invalid Input!");
                    }

                }

                Console.WriteLine("[?] Provide the new phone number.");

                while(true)
                {

                    string Input2 = Console.ReadLine();

                    var ValidInput = int.TryParse(Input2, out int n);

                    if(ValidInput == true)
                    {
                        
                        int ConvertedInput = Convert.ToInt32(Input2);

                        bool UniqueInput = database.PhoneNumberIsUnique(ConvertedInput);

                        if(UniqueInput == true)
                        {
                            PhoneNumberInput = Convert.ToInt32(Input2);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("[!] Phone number already exists!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("[!] Invalid Input!");
                    }

                }

                database.ChangePhoneNumber(IDInput,PhoneNumberInput);

            }
            else if(MainInput == "3")
            {

                Console.WriteLine("------------------------------");
                Console.WriteLine("[ Owners ]");

                List<OwnerArray> OwnerList = database.ReturnOwnerList();

                foreach(OwnerArray ownerArray in OwnerList)
                {
                    Console.WriteLine("Name: " + ownerArray.name + " | ID: " + Convert.ToString(ownerArray.id) + " | Phone Number: " + Convert.ToString(ownerArray.phone_number));
                }

                Console.WriteLine("------------------------------");
                Console.WriteLine("[ Pets ]");

                List<PetArray> PetList = database.ReturnPetList();

                foreach(PetArray petArray in PetList)
                {
                    Console.WriteLine("Name: " + petArray.name + " | ID: " + Convert.ToString(petArray.id) + " | Species: " + petArray.species +  " | Owner ID: " + Convert.ToString(petArray.owner_id));
                }

                Console.WriteLine("------------------------------");

            }
            else if(MainInput == "4")
            {

                int OwnerIDInput;
                int PetIDInput;
                string NameInput;
                string SpeciesInput;

                Console.WriteLine("[?] Provide the pet owner's ID.");

                while(true)
                {

                    string Input1 = Console.ReadLine();

                    var ValidInput = int.TryParse(Input1, out int n);

                    if(ValidInput == true)
                    {

                        int ConvertedInput = Convert.ToInt32(Input1);

                        bool UniqueInput = database.IDIsUnique(ConvertedInput);

                        if(UniqueInput == false)
                        {
                            OwnerIDInput = Convert.ToInt32(Input1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("[!] ID not found!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("[!] Invalid Input!");
                    }

                }

                Console.WriteLine("[?] Provide an ID for the pet.");

                while(true)
                {

                    string Input2 = Console.ReadLine();

                    var ValidInput = int.TryParse(Input2, out int n);

                    if(ValidInput == true)
                    {

                        int ConvertedInput = Convert.ToInt32(Input2);

                        bool UniqueInput = database.PetIDIsUnique(ConvertedInput);

                        if(UniqueInput == true)
                        {
                            PetIDInput = Convert.ToInt32(Input2);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("[!] Input not unique!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("[!] Invalid Input!");
                    }

                }
                
                Console.WriteLine("[?] Provide a name for the pet.");

                while(true)
                {

                    string Input3 = Console.ReadLine();

                    if(Input3 != "")
                    {
                        NameInput = Input3;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("[!] Invalid Input!");
                    }

                }

                Console.WriteLine("[?] Provide a species for the pet.");

                while(true)
                {

                    string Input4 = Console.ReadLine();

                    if(Input4 != "")
                    {
                        SpeciesInput = Input4;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("[!] Invalid Input!");
                    }

                }

                database.AddPet(PetIDInput, NameInput, SpeciesInput, OwnerIDInput);

            }
            else if(MainInput == "5")
            {

                Console.WriteLine("[?] Provide the name of the pet.");

                string NameToSearch;

                while(true)
                {

                    string NameInput = Console.ReadLine();

                    if(NameInput != "")
                    {
                        NameToSearch = NameInput;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("[!] Invalid Input!");
                    }

                }

                Console.WriteLine("------------------------------");

                List<OwnerArray> OwnerList = database.ReturnOwnerListWithPetName(NameToSearch);

                if(OwnerList.Count > 0)
                {
                    Console.WriteLine("[ Owners with a pet named: " + NameToSearch + " ]");

                    foreach(OwnerArray ownerArray in OwnerList)
                    {
                        Console.WriteLine("Name: " + ownerArray.name + " | ID: " + Convert.ToString(ownerArray.id) + " | Phone Number: " + Convert.ToString(ownerArray.phone_number));
                    }
                }
                else
                {
                    Console.WriteLine("No owners found with pet named: " + NameToSearch + "!");
                }

                Console.WriteLine("------------------------------");

            }
            else
            {
                Console.WriteLine("[!] Invalid Input!");
            }

        }

    }
}
