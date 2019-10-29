using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Clase19
{
    public class Mensaje:IMensaje
    {
        public override string ToString()
        {
            return this.Usuario + ": " + this.Texto + " - " + this.Hora.ToString("dd/MM/yyyy hh:mm:ss") ;
        }

        public void Serializar()
        {
                XmlTextWriter xmlTextWriter = new XmlTextWriter(@"Y:\Mensajes\" + this.Usuario + DateTime.Now.ToString("hhmmssttt"), Encoding.ASCII);
                XmlSerializer ser = new XmlSerializer(typeof(Mensaje));
                ser.Serialize(xmlTextWriter, this);
                xmlTextWriter.Close();            
        }

        public static List<Mensaje> Deserializar()
        {
            List<Mensaje> salida = new List<Mensaje>();
            foreach (string item in Directory.GetFiles(@"Y:\Mensajes\", "*.xml"))
            {
                XmlTextReader xmlText = new XmlTextReader(item);
                XmlSerializer ser = new XmlSerializer(typeof(Mensaje));
                salida.Add((Mensaje)ser.Deserialize(xmlText));
                xmlText.Close();
            }

            return salida;            

        }
    }
}
