using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace EnjoyPubLib.WebService
{

    /// <remarks/>
 
    [System.SerializableAttribute()] 
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://library.sh.cn/bookCollectionInfo/")]
    public  class BookCollectionDetailResponse
    {

        private string iSBNField;

        private int totalResultField;

        private BookCollectionDetailResponseCollectionDetailItem[] collectionDetailItemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string ISBN
        {
            get
            {
                return this.iSBNField;
            }
            set
            {
                this.iSBNField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public int TotalResult
        {
            get
            {
                return this.totalResultField;
            }
            set
            {
                this.totalResultField = value;
            }
        }

        /// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("CollectionItem", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public BookCollectionDetailResponseCollectionDetailItem[] CollectionDetailItem
        {
            get
            {
                return this.collectionDetailItemField;
            }
            set
            {
                this.collectionDetailItemField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]  
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://library.sh.cn/bookCollectionInfo/")]
    public partial class BookCollectionDetailResponseCollectionDetailItem
    {

		public string BookName{ get; set;}
        private string bookLocationField;

        private string bookLocationIDField;

        private string bookCollectionField;

        private string bookCallReconstField;

        private string bookItemStatusField;

        private string bookDueDateField;

        private string bookItypeField;

        private string bookIbarcodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string BookLocation
        {
            get
            {
                return this.bookLocationField;
            }
            set
            {
                this.bookLocationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string BookLocationID
        {
            get
            {
                return this.bookLocationIDField;
            }
            set
            {
                this.bookLocationIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public string BookCollection
        {
            get
            {
                return this.bookCollectionField;
            }
            set
            {
                this.bookCollectionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 3)]
        public string BookCallReconst
        {
            get
            {
                return this.bookCallReconstField;
            }
            set
            {
                this.bookCallReconstField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 4)]
        public string BookItemStatus
        {
            get
            {
                return this.bookItemStatusField;
            }
            set
            {
                this.bookItemStatusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 5)]
        public string BookDueDate
        {
            get
            {
                return this.bookDueDateField;
            }
            set
            {
                this.bookDueDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 6)]
        public string BookItype
        {
            get
            {
                return this.bookItypeField;
            }
            set
            {
                this.bookItypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 7)]
        public string BookIbarcode
        {
            get
            {
                return this.bookIbarcodeField;
            }
            set
            {
                this.bookIbarcodeField = value;
            }
        }
    }
}
