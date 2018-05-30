using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Eventrix_Client.Model;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.IO;
using WCF_SERVICE_CLIENT_HOST.Models.MappingModels;
using Newtonsoft.Json;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MappingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MappingService.svc or MappingService.svc.cs at the Solution Explorer and start debugging.
    public class MappingService : IMappingService
    {
        private string API_KEY = "AIzaSyBZG4nUTvkqIphqxAPyQAF9S1bPBT147Fc";

        public int createAddress(EventAddress _Address)
        {
            //int AD_ID = 0;
            //using (EventrixDBDataContext db = new EventrixDBDataContext())
            //{
                
            //        int query = (from ad in db.Addresses
            //                     where ad.AD_StreetName.Equals(_Address.STREET) && ad.AD_City.Equals(_Address.CITY)
            //                     && ad.AD_Province.Equals(_Address.PROVINCE) && ad.AD_Country.Equals(_Address.COUNTRY)
            //                     select ad).Count();
            //        if(query != 0)
            //        {
            //                     Address address = (from ad in db.Addresses
            //                     where ad.AD_StreetName.Equals(_Address.STREET) && ad.AD_City.Equals(_Address.CITY)
            //                     && ad.AD_Province.Equals(_Address.PROVINCE) && ad.AD_Country.Equals(_Address.COUNTRY)
            //                     select ad).FirstOrDefault();
            //                     AD_ID = address.AD_Id;
            //            return AD_ID;
            //        }
            //        else
            //        {
            //            Address toInsert = new Address();
            //            toInsert.AD_StreetName = _Address.STREET;
            //            toInsert.AD_City = _Address.CITY;
            //            toInsert.AD_Province = _Address.PROVINCE;
            //            toInsert.AD_Country = _Address.COUNTRY;
            //            db.Addresses.InsertOnSubmit(toInsert);
            //            db.SubmitChanges();
            //        }
             
            //};
            //using (EventrixDBDataContext db = new EventrixDBDataContext())
            //{
            //    var IDQuery = (from add in db.Addresses select add).ToList();
            //    Address IDs = IDQuery.Last();
            //    AD_ID = IDs.AD_Id;
            //    return AD_ID;
            //};
            try
            {
                using (EventrixDBDataContext dbd = new EventrixDBDataContext())
                {
                    Address toInsert = new Address();
                    toInsert.AD_StreetName = _Address.STREET;
                    toInsert.AD_City = _Address.CITY;
                    toInsert.AD_Province = _Address.PROVINCE;
                    toInsert.AD_Country = _Address.COUNTRY;
                    dbd.Addresses.InsertOnSubmit(toInsert);
                    dbd.SubmitChanges();
                };
                using (EventrixDBDataContext dbd = new EventrixDBDataContext())
                {
                    Address ad = dbd.Addresses.First(add => add.AD_StreetName.Equals(_Address.STREET) && add.AD_City.Equals(_Address.CITY)
                    && add.AD_Province.Equals(_Address.PROVINCE)
                     && add.AD_Country.Equals(_Address.COUNTRY));
                    int ID = ad.AD_Id;
                    return ID;
                };
            }
            catch (Exception)
            {
                return 000;
            }
        }

        public bool deleteAddress(EventAddress _address)
        {
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    int _id = Convert.ToInt32(_address.ID);
                    Address _ad = mde.Addresses.Single(_addr => _addr.AD_Id == _id);
                    //mde.EventHosts.Remove(pe);
                    //mde.SaveChanges();
                    mde.Addresses.DeleteOnSubmit(_ad);
                    mde.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            };
        }

        public string deleteAddressByID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    List<Address> toDelete = (from dl in db.Addresses where dl.AD_Id.Equals(_id) select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed: Image Not Found";
                    }
                    else
                    {
                        db.Addresses.DeleteAllOnSubmit(toDelete);
                        db.SubmitChanges();
                        return "success";
                    }
                };
            }
            catch (Exception)
            {
                return "Failed";
            }
        }

        public EventAddress getAddressById(string id)
        {
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var innerJoinQuery =
                    from address in db.Addresses
                    where address.AD_Id.Equals(Convert.ToInt32(id))
                    select new EventAddress
                    {
                        ID = address.AD_Id,
                        STREET = address.AD_StreetName,
                        CITY = address.AD_City,
                        LATITUDE = address.AD_Latitude,
                        LONGITUDE = address.AD_Longitude,
                        COUNTRY = address.AD_Country,
                        PROVINCE = address.AD_Province,
                    };
                    foreach (EventAddress ca in innerJoinQuery)
                    {
                        return ca;
                    }

                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<EventAddress> getAllAddresses()
        {
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    return db.Addresses.Select(address => new EventAddress
                    {
                        ID = address.AD_Id,
                        STREET = address.AD_StreetName,
                        CITY = address.AD_City,
                        COUNTRY = address.AD_Country,
                        PROVINCE = address.AD_Province,
                        LATITUDE = address.AD_Latitude,
                        LONGITUDE = address.AD_Longitude,
                    }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public EventAddress updateAddress(string id, EventAddress _Address)
        {
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
               try
                {
                    var query = (from add in db.Addresses where add.AD_Id.Equals(Convert.ToInt32(id)) select add);
                    if (query.Count() == 1)
                    {
                        Address add = query.Single();
                        add.AD_City = _Address.CITY;
                        add.AD_StreetName = _Address.STREET;
                        add.AD_Province = _Address.PROVINCE;
                        add.AD_Country = _Address.COUNTRY;
                        // add.AD_Latitude = _Address.LATITUDE;
                        //   add.AD_Longitude = _Address.LONGITUDE;
                        db.SubmitChanges();
                        _Address = new EventAddress()
                        {
                            STREET = add.AD_StreetName,
                            COUNTRY = add.AD_Country,
                            PROVINCE = add.AD_Province,
                            CITY = add.AD_City,
                            ID = add.AD_Id,
                            // LONGITUDE = add.AD_Longitude,
                            //  LATITUDE = add.AD_Latitude,
                        };
                        return _Address;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch(Exception)
                {
                    return null;
                }
            }
        }

        public List<string> getLatLong(string street, string town, string city)
        {
            List<string> diclatlong = new List<string>();
            string geoString = "https://maps.googleapis.com/maps/api/geocode/json?address=" + street + "," + town + "," + city + "&key=" + API_KEY;
            WebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(geoString);
                request.Method = "GET";
                response = request.GetResponse();
                if (response != null)
                {
                    string str = null;
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            str = streamReader.ReadToEnd();
                        }
                    }
                    GeoResponse geoResponse = JsonConvert.DeserializeObject<GeoResponse>(str);
                    if (geoResponse.Status == "OK")
                    {
                        int count = geoResponse.Results.Length;
                        for (int i = 0; i < count; i++)
                        {
                            diclatlong.Add(geoResponse.Results[i].Geometry.Location.Lat.ToString());
                            diclatlong.Add(geoResponse.Results[i].Geometry.Location.Lng.ToString());
                        }
                    }
                    else
                    {
                        diclatlong = null;
                    }
                }
            }
            catch
            {
                throw new Exception("JSON response failed.");
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
            return diclatlong;
        }

        public EventAddress getAddressByEventId(string eventid)
        {
            int _id = Convert.ToInt32(eventid);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    Address _address =
                   (from _event in db.MAIN_EVENTs
                    where _event.E_ID.Equals(_id)
                    join add in db.Addresses on _event.AD_Id equals add.AD_Id
                    select add).First();
                    EventAddress foundAddress = new EventAddress();
                    foundAddress.ID = _address.AD_Id;
                    foundAddress.STREET = _address.AD_StreetName;
                    foundAddress.CITY = _address.AD_City;
                    foundAddress.PROVINCE = _address.AD_Province;
                    foundAddress.COUNTRY = _address.AD_Country;
                    return foundAddress;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
