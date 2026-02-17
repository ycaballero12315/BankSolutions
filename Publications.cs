using System;
using System.Collections.Generic;
using System.Text;

namespace BankSolutions
{
    public enum PublicationType
    {
        Book,
        Magazine,
        Newspaper,
        Journal,
        Report
    }
    public abstract class Publications
    {
        private bool _published = false;
        private DateTime _datePublished;
        private int _totalPages;

        public Publications(string title, string publisher, PublicationType publicationType)
        {
            if (string.IsNullOrWhiteSpace(title)) 
                throw new ArgumentNullException("title"); 
            Title = title;
            if (string.IsNullOrWhiteSpace(publisher)) 
                throw new ArgumentNullException("publisher");
            Publisher = publisher;
            PublicationType = publicationType;
        }

        public string Title { get; }
        public string Publisher { get; }
        public PublicationType PublicationType { get; }

        public string? CopyrightName { get; private set; }
        public int CopyrightDate { get; private set; }

        public int Page {
            get {return _totalPages; } 
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException($"El valar tiene que se mayor a cero: {nameof(value)}");
                }
                _totalPages = value;
            }
        }
        public string GetPublicationDate()
        {
            if (!_published)
                return "NYP";
            else
                return _datePublished.ToString("d");
        }

        public void Publish(DateTime datePublished)
        {
            _published = true;
            _datePublished = datePublished;
        }

        public void Copyright(string copyrightName, int copyrightDate)
        {
            if (string.IsNullOrWhiteSpace(copyrightName))
                throw new ArgumentException("The name of the copyright holder is required.");
            CopyrightName = copyrightName;

            int currentYear = DateTime.Now.Year;
            if (copyrightDate < currentYear - 10 || copyrightDate > currentYear + 2)
                throw new ArgumentOutOfRangeException($"The copyright year must be between {currentYear - 10} and {currentYear + 1}");
            CopyrightDate = copyrightDate;
        }

        public override string ToString() => Title;
    }
}
