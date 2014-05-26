using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization.Json;
using System.Json;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Text;






namespace Risk
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                checkPostBack.Value = "true";
            else
                checkPostBack.Value = "false";
            System.Diagnostics.Debug.WriteLine(checkPostBack.Value);

            pmCheckBox1.InputAttributes.Add("class", "pmCheckBox");
            pmCheckBox2.InputAttributes.Add("class", "pmCheckBox");
            pmCheckBox3.InputAttributes.Add("class", "pmCheckBox");
            pmCheckBox4.InputAttributes.Add("class", "pmCheckBox");
            pmCheckBox5.InputAttributes.Add("class", "pmCheckBox");
            pmCheckBox6.InputAttributes.Add("class", "pmCheckBox");
            
            fvCheckBox1.InputAttributes.Add("class", "fvCheckBox");
            fvCheckBox2.InputAttributes.Add("class", "fvCheckBox");
            fvCheckBox3.InputAttributes.Add("class", "fvCheckBox");
            fvCheckBox4.InputAttributes.Add("class", "fvCheckBox");
            fvCheckBox5.InputAttributes.Add("class", "fvCheckBox");
            fvCheckBox6.InputAttributes.Add("class", "fvCheckBox");
            fvCheckBox7.InputAttributes.Add("class", "fvCheckBox");
            fvCheckBox8.InputAttributes.Add("class", "fvCheckBox");
            fvCheckBox9.InputAttributes.Add("class", "fvCheckBox");
            ocCheckBox1.InputAttributes.Add("class", "ocCheckBox");
            CheckBox2.InputAttributes.Add("class", "ocCheckBox2");
            CheckBox3.InputAttributes.Add("class", "ocCheckBox2");


            if (!IsPostBack)
            {
                var vc = new VariableAndConstant();
                
                this.dropCountryList.DataSource = vc.getCountryList();

                this.dropCountryList.DataValueField="Value";
                this.dropCountryList.DataTextField="Text";
                this.dropCountryList.DataBind();
                
                    
                
                
            }

                btnSubmit.Text = "Submit";
        }

        protected void fVCheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Write("OK1");
           //Response.Redirect(Request.UrlReferrer.PathAndQuery, true);
            Response.Write(Request.Form["txtResult"]);
            
        }

      
        protected void ocCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void ocCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        protected void ocCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
             
        }

        [DataContract]
        public class LendingType
        {
            [DataMember]
            String id { get; set; }
            [DataMember]
            String value { get; set; }
        };
        [DataContract]
        public class IncomeLevel
        {
            [DataMember]
            String id { get; set; }
            [DataMember]
            String value { get; set; }
        } ;
        [DataContract]
        public class Region
        {
            [DataMember]
            String id { get; set; }
            [DataMember]
            String region { get; set; }
        };
        [DataContract]
        public class AdminRegion
        {
            [DataMember]
            String id { get; set; }
            [DataMember]
            String region { get; set; }
        }

        [DataContract]
        public class Country {
            [DataMember]
            public String id { get; set; }
            [DataMember]
            public String iso2Code { get; set; }
            [DataMember]
            public String name { get; set; }
            [DataMember]
            public Region region { get; set; }
            [DataMember]
            public AdminRegion adminregion { get; set; }
            [DataMember]
            public IncomeLevel incomeLevel { get; set; }
            [DataMember]
            public LendingType lendingType { get; set; }
            [DataMember]
            public String capitalCity { get; set; }
            [DataMember]
            public String longitude { get; set; }
            [DataMember]
            public String latitude { get; set; }        
        }

        [DataContract]
        class Person
        {
            [DataMember]
            public string forename { get; set; }
            [DataMember]
            public string surname { get; set; }
            [DataMember]
            public int age { get; set; }

            [DataMember]
            public Address address { get; set; }
        }

        [DataContract]
        public class Address
        {
            [DataMember]
            public string line1 { get; set; }
            [DataMember]
            
            public string line2 { get; set; }
        }

        
 
        [DataContract]
        public class Indicator {
            [DataMember]
            public string id { get; set;}
            [DataMember]
            public string value { get; set;}

        }
         [DataContract]
        public class CountryIndicator {
            [DataMember]
            public string id { get; set;}
            [DataMember]
            public string value { get; set;}

        }
        [DataContract]
        public class wgiIndicator {
            [DataMember]
            public Indicator indicator {get; set;}
            [DataMember]
            public CountryIndicator country {get; set;}
            [DataMember]
            public string value {get; set;}
            [DataMember]
            public string _decimal {get; set;}
            [DataMember]
            public string date {get; set;}
        }

        public static T DeserializeJSon<T>(string jsonString)
        {
            
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
                T obj = (T)ser.ReadObject(stream);
                return obj;
            }
            catch (Exception e)
            {
                Debug.WriteLine("An exception occured while deserializing jsonString " + jsonString + e.Message);
                return default(T);
            }
            
           
        }

        protected async void bgGetWBData_Click(object sender, EventArgs e)
        {


            var selectedCountryId = dropCountryList.SelectedValue;
           // Debug.WriteLine(dropCountryList.SelectedItem.Value);
           // Debug.WriteLine(dropCountryList.SelectedValue);
           // Debug.WriteLine(dropCountryList.Items[dropCountryList.SelectedIndex].Value);
            
            Debug.WriteLine("The selected country : " + dropCountryList.SelectedItem.Value);
           // Debug.WriteLine(selectedCountryId);
            
            
            String[,] wgiIndicatorDefinition = new String[6,3]
                {
                    {"CC.EST", "Corruption control", ""},                 
                    {"GE.EST", "Government Effectiveness", ""},
                    {"PV.EST",  "Political Stability and Absence of Violence/Terrorism" , ""},
                    {"RL.EST", "Rule of Law", ""},
                    {"RQ.EST", "Regulatory Quality", ""},
                    {"VA.EST", "Voice and Accountability", ""}
                };

            var  wgiValues = new Dictionary<string, string[,]>();
            String selectedIndicator = "";

            

            
            for (int i = 0; i < 6; i++)
            {
                
                Debug.WriteLine("Beginning fetch " + DateTime.Now);

                selectedIndicator = wgiIndicatorDefinition[i, 0];
                Debug.Write("Selected indicator is " + selectedIndicator);
                
                StringBuilder s = new StringBuilder("http://api.worldbank.org/countries/" + selectedCountryId + "/indicators/" + selectedIndicator + "?source=3&format=json");
                Debug.Write("The built URI is = " + s);


                String getWgi = await RunAsync(s.ToString());
                
                Debug.WriteLine("Got the result from api " + DateTime.Now);

                if (getWgi.StartsWith("Error") || getWgi.StartsWith("ERROR") || getWgi.Equals("hello"))
                    Response.Write(getWgi);
                else
                {
                    Response.Write(getWgi);
                    var obj = DeserializeJSon<List<wgiIndicator>>(getWgi);
                    //Debug.WriteLine(obj.ToString());

                    Debug.WriteLine("Working on indicator " + selectedIndicator);
                   //indicatorValues =  getIndicatorValues(obj);

                    wgiValues.Add(selectedIndicator, getIndicatorValues(obj));

                }

                

                

            }


            


           
                
            
            //Response.Write("<SCRIPT> alert('Before async') </script>");
            //var uri = "http://api.worldbank.org/country?per_page=256&format=json";
            //Debug.WriteLine(uri);
            //String getWgi = "hello";


       

                /*
             var obj = DeserializeJSon<List<Country>>(getWgi);
             
             var countryList = "var countryList = [[\"id\",\"iso2Code\",\"name\"],";
             foreach (Country c in obj)
             {
                 countryList = countryList + ("[\"" + c.id + "\", \"" + c.iso2Code + "\", \"" + c.name + "\"],");
             }

             Response.Write(countryList);
              * */

            







         // List<Country> deserializedCountry = JsonConvert.DeserializeObject<List<Country>>(getWgi);
         /// Debug.WriteLine(deserializedCountry);
         //  Country country = deserializedCountry[0];
         //  Debug.WriteLine(country.ToString());


            /*
          DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Country>));
          stream = new MemoryStream(Encoding.UTF8.GetBytes(getWgi));
          obj = (List<Country>)ser.ReadObject(stream);
          foreach (Country c in obj)
              Console.WriteLine(c.ToString());
            */
            
        }

        private static String[,] getIndicatorValues(List<wgiIndicator> obj)
        {
            String[,] indicatorValues = new String[6, 2];
            //The following code can be refactored to a funciton to get average
            int count = 0;
            Double val = 0.000;
            if (obj == null)
                return indicatorValues;

            foreach (wgiIndicator i in obj)
            {
                Debug.WriteLine("Working on indicator year " + count);
                if (i.value.Equals("null") || i.value == null)
                    continue;
                if (count <= 4)
                {

                    indicatorValues[count, 0] = i.date;
                    indicatorValues[count, 1] = i.value;
                    val = val + Double.Parse(i.value);
                    Debug.WriteLine(count + " " + i.date + " " + i.value + "val is " + val);
                    count = count + 1;
                }
                else
                    break;
            }
            indicatorValues[5, 0] = "Average";
            indicatorValues[5, 1] = Convert.ToString(val / (count));

            Debug.WriteLine(indicatorValues.Length);
            for (int i = 0; i < 6; i++)
            {
                Debug.WriteLine(indicatorValues[i, 0] + " " + indicatorValues[i, 1]);
            }

            return indicatorValues;
        }
        /*
         * This method returns a serialized data in json format for a webclient.
         * the method does not check the correctness of uri.
         * For any error, the returned string starts with "ERROR". This informaiton
         * can be used to provide appropriate message.
         * 
         */
        static async Task<String> RunAsync(String uri)
        {
            Debug.WriteLine("outside");
            using (var client = new System.Net.Http.HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Debug.WriteLine(uri);
                HttpResponseMessage response = await client.GetAsync(uri);          

                String  responseBody="";
                Debug.WriteLine(response.IsSuccessStatusCode);
                //Debug.WriteLine(response.ToString());

                if (response.IsSuccessStatusCode)
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                    //Debug.WriteLine("Before parsing " + responseBody);
                    /* The API is giving a page header. The following string parsing removes the extra string and makes string to
                     * comply with strict json format.
                     *
                     */
                    int x = responseBody.IndexOf(",[{\"");
                    //Debug.WriteLine("First occurence of [{\" " + x);
                    int y = responseBody.LastIndexOf("]");
                    responseBody = responseBody.Substring(x+1, y - x);
                    responseBody = responseBody.Replace("decimal", "_decmial");
                   
                    Debug.WriteLine("After parsing " + responseBody);
                    if (responseBody.StartsWith("[{\"page\""))
                    {
                        responseBody = "ERROR - no data exist for selected location/indicator ";
                    }

                }
                else
                    responseBody = ("ERROR " + response.StatusCode.ToString());

                return responseBody;
            }
        }

  
    }
}