using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HotelReservationProject
{
       class HotelReservation
        {
            public static List<HotelReservation> listobj = new List<HotelReservation>();

            public string name { get; set; }    //Assigning the values
            public int r { get; set; }
            public int r_wd { get; set; }
            public int r_w { get; set; }
            public int reward_wd { get; set; }
            public int reward_w { get; set; }
            public void AddHotel()
            {
                HotelReservation h = new HotelReservation();
                Console.WriteLine("enter the hotel name");
                h.name = Console.ReadLine();
                Console.WriteLine("enter the hotel Rating");
                h.r = int.Parse(Console.ReadLine());
                Console.WriteLine("enter the rate for regular customers in weekdays(Monday-Friday)");
                h.r_wd = int.Parse(Console.ReadLine());
                Console.WriteLine("enter the rate for regular customers in weekends(Sturday and sunday)");
                h.r_w = int.Parse(Console.ReadLine());
                Console.WriteLine("enter the rate for reward customers in weekdays(Monday-Friday)");
                h.reward_wd = int.Parse(Console.ReadLine());
                Console.WriteLine("enter the rate for reward customers in weekends(saturday and sunday)");
                h.reward_w = int.Parse(Console.ReadLine());

                listobj.Add(h);

                Console.WriteLine("do you want check another option:");
                string op = Console.ReadLine();
                if (op.ToLower() == "yes")
                {
                    MainHotelReservation.Main(new string[] { });


                }

            }
            public void HotelDetails()
            {
                Console.WriteLine("Available Hotels and the amount for the customers");
                foreach( HotelReservation h in listobj )
                {
                    Console.WriteLine($"Hotel Name: {h.name}");
                    Console.WriteLine($"Hotel rate: {h.r}");
                    Console.WriteLine($"Amount in weekdays for regular customers: {h.r_wd}");
                    Console.WriteLine($"Amount in weekends for regular customers: {h.r_w}");
                    Console.WriteLine($"Amount in weedays for reward customers: {h.reward_wd}");
                    Console.WriteLine($"Amount in weekends for reward customers: {h.reward_w}");
                    Console.WriteLine();
                }

                Console.WriteLine("do you want check another option:");
                string op = Console.ReadLine();
                if (op.ToLower() == "yes")
                {
                    MainHotelReservation.Main(new string[] { });


                }

            }

        }
        class MainHotelReservation
        {



            public static void Main(string[] args)
            {
                HotelReservation obj=new HotelReservation();
                Console.WriteLine("************WELCOME TO HOTEL RESERVATION SYSTEM**************");
                Console.WriteLine();
                Console.WriteLine("1.Add Hotel\n2.Hotel Details");
                Console.WriteLine("enter the choice");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        obj.AddHotel();
                        break;
                    case 2:
                        obj.HotelDetails();
                        break;
                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            }


        }

}

