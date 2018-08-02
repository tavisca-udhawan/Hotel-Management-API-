using Hotel_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hotel_Management_System.Controllers
{
    public class HotelController : ApiController
    {
        public static int _IdCounter = 15;
        public static List<HotelDetails> hotelDetails = new List<HotelDetails>() {
            new HotelDetails{ID=11,Name="Cosmo Luxury",AvailableRooms=15,Address="Viman Nagar",Code="PNQ"},
            new HotelDetails{ID=12,Name="Hyatt Regency",AvailableRooms=15,Address="Goregaon",Code="PNQ"},
            new HotelDetails{ID=13,Name="JW Marriot",AvailableRooms=15,Address="Sector-34",Code="CHD"},
            new HotelDetails{ID=14,Name="Grand INN",AvailableRooms=15,Address="Sector-22",Code="CHD"}

        };
        [HttpGet]
        public HotelStatus GetData()
        {
            try
            {
                return new HotelStatus()
                {
                    Hotels = hotelDetails,

                    Status = new EventStatus()
                    {
                        code = 200,
                        message = string.Empty,
                        response = Status.Success
                    }
                };
            }
            catch (Exception ex)
            {
                return new HotelStatus()
                {

                    Status = new EventStatus()
                    {
                        code = 404,
                        message = "No Available Hotels yet!!",
                        response = Status.Failure
                    }
                };
            }
        }

        [HttpGet]
        public StatusById GetDataByID(int Id)
        {
            HotelDetails data = hotelDetails.Find(value => value.ID == Id);

            try
            {
                if (data != null)
                {
                    return new StatusById()
                    {
                        Hotel = data,
                        Status = new EventStatus()
                        {
                            code = 200,
                            message = "Searching Successfully done!!",
                            response = Status.Success
                        }

                    };
                }
                else
                {
                    return new StatusById()
                    {

                        Status = new EventStatus()
                        {
                            code = 404,
                            message = "Hotel you are looking for, does not Exists!!",
                            response = Status.Failure
                        }
                    };
                }
            }


            catch (Exception ex)
            {

                return new StatusById()
                {

                    Status = new EventStatus()
                    {
                        code = 404,
                        message = "Hotel you are looking for, does not Exists!!",
                        response = Status.Failure
                    }
                };
            }

        }
        [HttpDelete]
        public StatusById Delete(int id)
        {
            HotelDetails details = hotelDetails.Find(deleteData => deleteData.ID == id);
            try
            {
                if (details != null)
                {
                    hotelDetails.Remove(details);
                    return new StatusById()
                    {

                        Status = new EventStatus()
                        {
                            code = 200,
                            message = "The record with id " + id + " has been deleted.",
                            response = Status.Success
                        }

                    };
                }
                else
                {
                    return new StatusById()
                    {

                        Status = new EventStatus()
                        {
                            code = 404,
                            message = "Hotel Not Found",
                            response = Status.Failure
                        }
                    };
                }
            }


            catch (Exception ex)
            {

                return new StatusById()
                {

                    Status = new EventStatus()
                    {
                        code = 404,
                        message = "Hotel Not Found!!",
                        response = Status.Failure
                    }
                };
            }

        }
        [HttpPost]
        public StatusById PostMethod(HotelDetails obj)
        {

            try
            {
                obj.ID = _IdCounter;
                _IdCounter++;
                hotelDetails.Add(obj);

                return new StatusById()
                {

                    Status = new EventStatus()
                    {
                        code = 200,
                        message = "The record has been added Successfully.",
                        response = Status.Success
                    }

                };

            }


            catch (Exception ex)
            {

                return new StatusById()
                {

                    Status = new EventStatus()
                    {
                        code = 500,
                        message = "Not Created!!",
                        response = Status.Failure
                    }
                };
            }
        }
        [HttpPut]
        public StatusById PutMethod(int Id,[FromBody]int NoOfRooms)
        {
            int value = hotelDetails.FindIndex(hotelDetails => hotelDetails.ID==Id);
            if (value !=-1)
            {
                hotelDetails[value].AvailableRooms -= NoOfRooms;
                return new StatusById()
                {
                   
                    Status = new EventStatus()
                    {
                        code = 200,
                        message = "Booking has been successfully Done!!",
                        response = Status.Success
                    }

                };
            }
            else
            {
                return new StatusById()
                {

                    Status = new EventStatus()
                    {
                        code = 404,
                        message = "Hotel does not exist",
                        response = Status.Failure
                    }
                };
            }

        }
    }
}