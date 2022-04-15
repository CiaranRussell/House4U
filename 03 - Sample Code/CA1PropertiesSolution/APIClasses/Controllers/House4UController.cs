using House4U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace House4U.Controllers
{
    namespace House4U.Controllers
    {
        [RoutePrefix("api")]
        public class House4UController : ApiController
        {
            List<Client> ClientData = new List<Client>();
            List<Property> PropertyData = new List<Property>();

            House4UController() : base()
            {
                Client c1 = new Client() { ID = 0, Name = "Landlord Jim", Phone = "087-555555", EmailAddress = "Jim@allprops.com" };
                Client c2 = new Client() { ID = 1, Name = "Landlord Jane", Phone = "088-555555", EmailAddress = "Jane@alltheotherprops.com" };
                ClientData.Add(c1);
                ClientData.Add(c2);

                Property p1 = new Property() { ID = 0, Address = "1 The street", BedroomCount = 3, FullyDelegated = false, LeaseExpiry = new DateTime(2020, 1, 1), ClientID = 0 };
                Property p2 = new Property() { ID = 1, Address = "1 The Road", BedroomCount = 16, FullyDelegated = false, LeaseExpiry = new DateTime(2020, 1, 1), ClientID = 1 };
                Property p3 = new Property() { ID = 2, Address = "1 The Apartment Block", BedroomCount = 3, FullyDelegated = false, LeaseExpiry = new DateTime(2020, 1, 1), ClientID = 1 };
                PropertyData.Add(p1);
                PropertyData.Add(p2);
                PropertyData.Add(p3);
            }

            //Operation 1 - Add a client
            [Route("AddClient")]
            // POST: api/AddClient
            public string Post([FromBody]Client value)
            {
                if (value != null)
                {
                    try
                    {
                        value.ID = ClientData.Count();
                        ClientData.Add(value);
                        return "Client added";
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }
                else
                {
                    return "Invalid input!";
                }
            }

            //Operation 2 - Add a property
            [Route("AddProp")]
            // POST: api/AddProp
            public string Post([FromBody]Property value)
            {
                if (value != null)
                {
                    try
                    {
                        value.ID = PropertyData.Count();
                        PropertyData.Add(value);
                        return "Property added";
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }
                else
                {
                    return "Invalid input!";
                }
            }


            //Operation 3 - Update no. of bedrooms
            [Route("Update/{id}")]
            // PUT: api/Update
            public string Put(int id, [FromBody]Property value)
            {
                if (value != null)
                {
                    try
                    {
                        Property prop = PropertyData.FirstOrDefault(p => p.ID.Equals(id));
                        if (prop !=null)
                        {
                            prop.BedroomCount = value.BedroomCount;
                            return "Property updated";
                        }
                        else
                        {
                            return ("Failed to find property!");
                        }

                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }
                else
                {
                    return "Invalid input!";
                }
            }

            //Operation 4 - GET all client sorted by client name
            [Route("AllClientsByName")]
            public List<Client> GetAllClientsByName()
            {
                return ClientData.OrderBy(p => p.Name).ToList();
            }

            //Operation 5 - GET all client sorted by client id
            [Route("AllClientsByID")]
            public List<Client> GetAllClientsByID()
            {
                return ClientData.OrderBy(p => p.ID).ToList();
            }

            //Operation 6 - GET all properties
            // GET: api/AllProps
            [Route("AllProps")]
            public List<Property> GetAllProps()
            {
                return PropertyData;
            }


            //Operation 7 - GET all properties by client id
            [Route("AllPropsForClientID/{id}")]
            // GET: api/AllPropsForClientID/5
            public List<Property> GetPropsForClientID(int id)
            {
                return PropertyData.Where(h => h.ClientID.Equals(id)).ToList();
            }

            //Operation 8 - GET all properties by client name
            [Route("AllPropsForClientName/{name}")]
            // GET: api/AllPropsForClientName/NAME
            public List<Property> GetPropsForClientName(string name)
            {
                Client c = ClientData.FirstOrDefault(p => p.Name.Equals(name));
                if (c != null)
                {
                    return PropertyData.Where(h => h.ClientID.Equals(c.ID)).ToList();
                }
                return null;
            }
        }
    }
}
