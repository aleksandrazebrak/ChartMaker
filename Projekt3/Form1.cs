using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


namespace Projekt3
{
    

    public partial class Form1 : Form
    {
       string[] elementy = {};
        int iloscElementow = 0;
        bool done = true;
        
        public Form1()
        {
            InitializeComponent();
            
            
        
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            openFileDialog1.Filter = "xy files(*.xy)|*.xy";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                done = false;
                chart1.Series["Series1"].Points.Clear();
                chart1.Series["Series2"].Points.Clear();
                chart1.Series["Series3"].Points.Clear();
                System.IO.StreamReader myStreamReader = new
                System.IO.StreamReader(openFileDialog1.FileName);


                
                elementy = myStreamReader.ReadToEnd().Split(new char[] {' ', '\n'});
                
                iloscElementow = elementy.Length;
                
                PointF myPoint = new PointF();



                
                for (int i = 0; i < iloscElementow - 3; i = i+2)
                {

                    
                    myPoint.X = float.Parse(elementy[i],new CultureInfo("en-US"));
                    myPoint.Y = float.Parse(elementy[i + 1], new CultureInfo("en-US"));
                    
                    chart1.Series["Series1"].Points.AddXY(myPoint.X, myPoint.Y);
                    

                     
                  }
                
                
                  
                
                myStreamReader.Close();

                    

                    
                
                
            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
           

            if (done == false)
            {
                float wartoscNajwyzsza = float.Parse(elementy[0], new CultureInfo("en-US"));
                int wartoscNajwyzszaNr = 0;
                for (int i = 1; i < iloscElementow - 3; i = i + 2)
                {


                    if (float.Parse(elementy[i], new CultureInfo("en-US")) > wartoscNajwyzsza)
                    {
                        wartoscNajwyzsza = float.Parse(elementy[i], new CultureInfo("en-US"));
                        wartoscNajwyzszaNr = i;
                    }
                }

                int wartoscNajwyzszaNrX = wartoscNajwyzszaNr - 1;
                float Xnajwyzsza = float.Parse(elementy[wartoscNajwyzszaNrX], new CultureInfo("en-US"));

                chart1.Series["Series2"].Points.AddXY(Xnajwyzsza, wartoscNajwyzsza);

                float wartoscNajnizsza = float.Parse(elementy[1], new CultureInfo("en-US"));
                int wartoscNajnizszaNr = 0;

                for (int i = 1; i < iloscElementow - 3; i = i + 2)
                {


                    if (float.Parse(elementy[i], new CultureInfo("en-US")) < wartoscNajnizsza)
                    {
                        wartoscNajnizsza = float.Parse(elementy[i], new CultureInfo("en-US"));
                        wartoscNajnizszaNr = i;
                    }
                }

                int wartoscNajnizszaNrX = wartoscNajnizszaNr - 1;
                float Xnajnizsza = float.Parse(elementy[wartoscNajnizszaNrX], new CultureInfo("en-US"));

                chart1.Series["Series2"].Points.AddXY(Xnajnizsza, wartoscNajnizsza);

                float fPolowa = (wartoscNajwyzsza - wartoscNajnizsza) / 2;

                

                chart1.Series["Series3"].Points.AddXY(chart1.ChartAreas[0].AxisX.Minimum, fPolowa);
                chart1.Series["Series3"].Points.AddXY(chart1.ChartAreas[0].AxisX.Maximum, fPolowa);


                chart1.Series["Series3"].Points[0].Label = "1/2 max = #VAL{N2}";
                done = true;

                
                
                //------chujowe poczatki szukania punktow-------------//
                
                PointF najblizszyPrawoGora = new PointF();
                


                float MojaRoznicaWartosci = Math.Abs(float.Parse(elementy[1], new CultureInfo("en-US")) - fPolowa);
                float MojaRoznicaWartosci2 = Math.Abs(float.Parse(elementy[1], new CultureInfo("en-US")) - fPolowa);

                for (int i = wartoscNajwyzszaNr; i < iloscElementow - 3; i = i + 2)
                {
                   float roznica = float.Parse(elementy[i], new CultureInfo("en-US")) - fPolowa;

                    if (roznica < MojaRoznicaWartosci && roznica > 0)
                    {
                       MojaRoznicaWartosci = roznica;
                       najblizszyPrawoGora.X = float.Parse(elementy[i - 1], new CultureInfo("en-US"));
                       najblizszyPrawoGora.Y = float.Parse(elementy[i], new CultureInfo("en-US"));
                   }
                
                }

               
                    
                    chart1.Series["Series2"].Points.AddXY(najblizszyPrawoGora.X, najblizszyPrawoGora.Y);







                   
                }
               

                
                


           


               }

               
                
            
            
            
            }
                
            
           
            
        }

                      
                

               
              

    


      
    




