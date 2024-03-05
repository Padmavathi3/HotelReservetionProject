using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
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

        //Add the Hotel Details
        public void addHotel()
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
                MainHotel.Main(new string[] { });


            }

        }


        //Display the hotel details
        public void hotelDetails()
        {
            Console.WriteLine("Available Hotels and the amount for the customers");
            foreach (HotelReservation h in listobj)
            {
                Console.WriteLine($"Hotel Name: {h.name}");
                Console.WriteLine($"Hotel rate: {h.r}");
                Console.WriteLine($"Amount in weedays for regular customers: {h.r_wd}");
                Console.WriteLine($"Amount in weekends for regular customers: {h.r_w}");
                Console.WriteLine($"Amount in weedays for reward customers: {h.reward_wd}");
                Console.WriteLine($"Amount in weekends for reward customers: {h.reward_w}");
                Console.WriteLine();
            }

            Console.WriteLine("do you want check another option:");
            string op = Console.ReadLine();
            if (op.ToLower() == "yes")
            {
                MainHotel.Main(new string[] { });


            }

        }



        //Finding cheapest hotel
        public void findingCheapHotel()
        {
            Dictionary<string, int> sumd = new Dictionary<string, int>();
            Dictionary<string, int> rated = new Dictionary<string, int>();
            Dictionary<string, int> reward_sumd = new Dictionary<string, int>();
            Dictionary<string, int> reward_rated = new Dictionary<string, int>();


            Console.WriteLine("enter the from date");
            DateTime f_date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(f_date.DayOfWeek);
            Console.WriteLine("enter the to date");
            DateTime t_date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(t_date.DayOfWeek);
            Console.WriteLine("enter customer type(regular or reward)");
            string type = Console.ReadLine();
            Console.WriteLine("enter customer like(based on rating or cost) either rating or cost");
            string like = Console.ReadLine();

            //find hotel for regular customer
            if (type == "regular")
            {
                foreach (HotelReservation h in listobj)
                {
                    int sum = 0;
                    for (DateTime date = f_date; date < t_date; date = date.AddDays(1))
                    {
                        //
                        //Console.WriteLine(date.DayOfWeek);
                        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                        {
                            sum += h.r_w;
                            //Console.WriteLine("Weekend: " + date.DayOfWeek);
                        }
                        else
                        {
                            sum += h.r_wd;
                            //Console.WriteLine("Weekday: " + date.DayOfWeek);
                        }
                    }

                    sumd.Add(h.name, sum);
                    rated.Add(h.name, h.r);
                    Console.WriteLine($"Hotel name:{h.name} Hotel rating {h.r} Hotel Cost {sum}");


                }
                Console.WriteLine();
                if (like == "cost")
                {
                    if (sumd.Count > 0)
                    {
                        int smallestValue = int.MaxValue;
                        string smallestString = null;

                        foreach (var pair in sumd)
                        {
                            if (pair.Value < smallestValue)
                            {
                                smallestValue = pair.Value;
                                smallestString = pair.Key;
                            }
                        }

                        if (smallestString != null)
                        {
                            Console.WriteLine($"Less Cost and hotel name ({smallestValue}): {smallestString}");
                        }
                        else
                        {
                            Console.WriteLine("Dictionary is empty");
                        }

                    }
                }
                else if (like == "rating")
                {
                    if (rated.Count > 0)
                    {
                        int highestValue = int.MinValue; // Initialize to the lowest possible value
                        string highestString = null;

                        foreach (var pair in rated)
                        {
                            if (pair.Value > highestValue)
                            {
                                highestValue = pair.Value;
                                highestString = pair.Key;
                            }
                        }

                        if (highestString != null)
                        {
                            Console.WriteLine($" High Quality and hotel name({highestValue}): {highestString}");
                        }
                        else
                        {
                            Console.WriteLine("Dictionary is empty.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("This type of customer not exist");
                }
            }


            //finding cheapest hotel for reward customers
            else if (type == "reward")
            {
                foreach (HotelReservation h in listobj)
                {
                    int sum = 0;
                    for (DateTime date = f_date; date < t_date; date = date.AddDays(1))
                    {
                        //Console.WriteLine(date.DayOfWeek);
                        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                        {
                            sum += h.reward_w;
                            //Console.WriteLine("Weekend: " + date.DayOfWeek);
                        }
                        else
                        {
                            sum += h.reward_wd;
                            //Console.WriteLine("Weekday: " + date.DayOfWeek);
                        }
                    }

                    reward_sumd.Add(h.name, sum);
                    reward_rated.Add(h.name, h.r);
                    Console.WriteLine($"Hotel name:{h.name} Hotel rating {h.r} Hotel Cost {sum}");
                }
                if (like == "cost")
                {
                    if (reward_sumd.Count > 0)
                    {
                        int smallestValue = int.MaxValue;
                        string smallestString = null;

                        foreach (var pair in reward_sumd)
                        {
                            if (pair.Value < smallestValue)
                            {
                                smallestValue = pair.Value;
                                smallestString = pair.Key;
                            }
                        }

                        if (smallestString != null)
                        {
                            Console.WriteLine($"Less Cost and hotel name ({smallestValue}): {smallestString}");
                        }

                    }
                }
                else if (like == "rating")
                {
                    if (reward_rated.Count > 0)
                    {
                        int highestValue = int.MinValue; // Initialize to the lowest possible value
                        string highestString = null;

                        foreach (var pair in reward_rated)
                        {
                            if (pair.Value > highestValue)
                            {
                                highestValue = pair.Value;
                                highestString = pair.Key;
                            }
                        }

                        if (highestString != null)
                        {
                            Console.WriteLine($" High Quality and hotel name({highestValue}): {highestString}");
                        }
                        else
                        {
                            Console.WriteLine("Dictionary is empty.");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("this type of customer was not exist");
            }

        }

    }
    class MainHotel
    {



        public static void Main(string[] args)
        {
            HotelReservation obj = new HotelReservation();
            Console.WriteLine("************WELCOME TO HOTEL RESERVATION SYSTEM**************");
            Console.WriteLine();
            Console.WriteLine("1.Add Hotel\n2.Hotel Details\n3.Finding cheapest hotel");
            Console.WriteLine("enter the choice");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    obj.addHotel();
                    break;
                case 2:
                    obj.hotelDetails();
                    break;
                case 3:
                    obj.findingCheapHotel();
                    break;
                default:
                    Console.WriteLine("invalid choice");
                    break;
            }
        }


    }

}

