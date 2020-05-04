using System;
using System.Collections.Generic;

// This program solves OCP using Visitor
namespace OCP_Visitor
{
    public abstract class DocumentPart
    {
        public abstract void Paint();

        public abstract void Save();

        public abstract void Convert(IDocumentConverter obj);

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

        public override void Convert(IDocumentConverter converterObj)
        {
            converterObj.ConvertParagraph(this);
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

        public override void Convert(IDocumentConverter converterObj)
        {
            converterObj.ConvertHyperLink(this);
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

        public override void Convert(IDocumentConverter converterObj)
        {
            converterObj.ConvertHeader(this);
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

        public override void Convert(IDocumentConverter converterObj)
        {
            converterObj.ConvertFooter(this);
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
            foreach (var v in parts)
            {
                v.Convert(obj);
            }
        }
    }

    public class OCP_Visitor
    {
        public static void Main()
        {
            Document1 obj = new Document1();
            obj.Add(new Paragraph());
            obj.Add(new Header());
            obj.Add(new Footer());
            obj.Add(new HyperLink());
            obj.Convert(new PDFConverter());
            obj.Convert(new HTMLConverter());
        }
    }
}
