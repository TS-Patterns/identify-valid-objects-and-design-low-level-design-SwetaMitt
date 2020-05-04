
using System;
using System.Collections.Generic;


// Liskov Substitution Principle using down casting and switch
namespace ConsoleApplication1
{
    public abstract class DocumentPart
    {
        public abstract void Paint();

        public abstract void Save();

    }


    public class Paragraph : DocumentPart
    {
        public override void Paint()
        {
           Console.WriteLine("");
        }

        public override void Save()
        {
           Console.WriteLine("");
        }

    }

    public class HyperLink : DocumentPart
    {
        public override void Paint()
        {
           Console.WriteLine("");
        }

        public override void Save()
        {
           Console.WriteLine("");
        }
    }


    public class Header : DocumentPart
    {
        public override void Paint()
        {
           Console.WriteLine("");
        }

        public override void Save()
        {
           Console.WriteLine("");
        }
    }

    public class Footer : DocumentPart
    {
        public override void Paint()
        {
            Console.WriteLine("");
        }

        public override void Save()
        {
            Console.WriteLine("");
        }
    }
    public interface IDocumentConverter
    {
        void ConvertParagraph(Paragraph obj);
		void ConvertHeader(Header obj);
        void ConvertFooter(Footer obj);
        void ConvertHyperLink(HyperLink obj);
    }

    public class PDFConverter : IDocumentConverter
    {
        public void ConvertParagraph(Paragraph obj)
        {
            Console.WriteLine("PDFConverter:Paragraph");
        }

        public void ConvertHeader(Header obj)
        {
            Console.WriteLine("PDFConverter:Header");
        }

        public void ConvertFooter(Footer obj)
        {
            Console.WriteLine("PDFConverter:Footer");
        }

        public void ConvertHyperLink(HyperLink obj)
        {
            Console.WriteLine("PDFConverter:HyperLink");
        }
    }

    public class HTMLConverter : IDocumentConverter
    {
        public void ConvertParagraph(Paragraph obj)
        {
            Console.WriteLine("HTMLConverter:Paragraph");
        }

        public void ConvertHeader(Header obj)
        {
            Console.WriteLine("HTMLConverter:Header");
        }

        public void ConvertFooter(Footer obj)
        {
            Console.WriteLine("HTMLConverter:Footer");
        }

        public void ConvertHyperLink(HyperLink obj)
        {
            Console.WriteLine("HTMLConverter:HyperLink");
        }
    }

    public class Document1
    {
        public List<DocumentPart> parts = new List<DocumentPart>();

        public void Add(DocumentPart doc)
        {
            parts.Add(doc);

        }

        public void Convert(IDocumentConverter obj)
        {
            PDFConverter p = new PDFConverter();
            foreach (var v in parts)
            {
                //p.ConvertParagraph(v);
                Type type = v.GetType();
                Console.WriteLine(type.ToString());
                switch (type.Name)
                {
                    case "Paragraph":
                        p.ConvertParagraph((Paragraph)v);
                        break;
                    case "Header":
                        p.ConvertHeader((Header)v);
                        break;
                    case "Footer":
                        p.ConvertFooter((Footer)v);
                        break;
                    case "HyperLink":
                        p.ConvertHyperLink((HyperLink)v);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public class LSP_Switch
    {
        public static void Main()
        {
            Document1 obj = new Document1();
            obj.Add(new Paragraph());
            obj.Add(new Header());
            obj.Add(new Footer());
            obj.Add(new HyperLink());
            obj.Convert(new PDFConverter());
        }
    }
}