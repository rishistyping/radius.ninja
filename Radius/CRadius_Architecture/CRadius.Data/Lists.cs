using System;
using System.Collections.Generic;
using System.Linq;

namespace CRadius.Data
{
    public static class Lists
    {
        public static List<Item> locationType;
        public static List<Item> direction;
        public static List<Item> sector;
        public static List<Item> scale;
        public static List<Item> announcementType;
        public static List<Item> invoiceStatus;
        public static List<Item> securityQuestion;
        public static List<Item> subscriberType;
        public static List<Item> permissions;
        public static List<Item> blockchain;
        public static List<Item> title;
        public static List<Item> sex;
        public static List<Item> status;
        public static List<Item> contractType;
        public static List<Item> maritalStatus;
        public static List<Item> relationship;

        public enum StringType
        {
            Scale = 1,
            Title = 2,
            Sex = 3,
            Status = 4,
            ContractType = 5,
            MaritalStatus = 6,
            Relationship = 7,
            SubscriberType = 8,
            SecurityQuestion = 9,
            InvoiceStatus = 10,
            AnnouncementType = 11,
            Sector = 12,
            Direction = 13,
            LocationType = 14,
        }

        public static List<Item> LocationType
        {
            get { return locationType; }
        }

        public static List<Item> Direction
        {
            get { return direction; }
        }

        public static List<Item> Sector
        {
            get { return sector; }
        }

        public static List<Item> Scale
        {
            get { return scale; }
        }

        public static List<Item> AnnouncementType
        {
            get { return announcementType; }
        }

        public static List<Item> InvoiceStatus
        {
            get { return invoiceStatus; }
        }

        public static List<Item> SecurityQuestion
        {
            get { return securityQuestion; }
        }

        public static List<Item> SubscriberType
        {
            get { return subscriberType; }
        }

        public static List<Item> Permissions
        {
            get { return permissions; }
        }

        public static List<Item> Blockchain
        {
            get { return blockchain; }
        }

        public static List<Item> Relationship
        {
            get { return relationship; }
        }

        public static List<Item> MaritalStatus
        {
            get { return maritalStatus; }
        }

        public static List<Item> ContractType
        {
            get { return contractType; }
        }

        public static List<Item> Status
        {
            get { return status; }
        }

        public static List<Item> Sex
        {
            get { return sex; }
        }

        public static List<Item> Title
        {
            get { return title; }
        }

        public static void Initialise()
        {
            locationType = new List<Item>();

            locationType.Add(new Item("0", String.Empty, String.Empty, false));
            locationType.Add(new Item("1", "Radius", String.Empty, false));
            locationType.Add(new Item("2", "Polygon", String.Empty, false));

            direction = new List<Item>();

            direction.Add(new Item("0", String.Empty, String.Empty, false));
            direction.Add(new Item("1", "Enter", String.Empty, false));
            direction.Add(new Item("2", "Leave", String.Empty, false));
            direction.Add(new Item("3", "Cross", String.Empty, false));

            sector = new List<Item>();

            sector.Add(new Item("0", String.Empty, String.Empty, false));
            sector.Add(new Item("1", "Accounting", String.Empty, false));
            sector.Add(new Item("2", "Aerospace", String.Empty, false));
            sector.Add(new Item("3", "Construction", String.Empty, false));
            sector.Add(new Item("4", "Defence", String.Empty, false));
            sector.Add(new Item("5", "Education", String.Empty, false));
            sector.Add(new Item("6", "Energy", String.Empty, false));
            sector.Add(new Item("7", "Financial Services", String.Empty, false));
            sector.Add(new Item("8", "Fishing", String.Empty, false));
            sector.Add(new Item("9", "Forestry", String.Empty, false));
            sector.Add(new Item("10", "Healthcare", String.Empty, false));
            sector.Add(new Item("11", "Hospitality", String.Empty, false));
            sector.Add(new Item("12", "Information Technology", String.Empty, false));
            sector.Add(new Item("13", "Legal", String.Empty, false));
            sector.Add(new Item("14", "Mining", String.Empty, false));
            sector.Add(new Item("15", "Manufacturing", String.Empty, false));
            sector.Add(new Item("16", "Mass media", String.Empty, false));
            sector.Add(new Item("17", "Retail", String.Empty, false));
            sector.Add(new Item("18", "Telecommunications", String.Empty, false));
            sector.Add(new Item("19", "Transport", String.Empty, false));
            sector.Add(new Item("20", "Water", String.Empty, false));
            sector.Add(new Item("21", "Other", String.Empty, false));

            scale = new List<Item>();

            scale.Add(new Item("0", String.Empty, String.Empty, false));
            scale.Add(new Item("1", "Multiple choice 1-5", String.Empty, false));
            scale.Add(new Item("2", "Score out of ten", String.Empty, false));
            scale.Add(new Item("3", "Percentage", String.Empty, false));
            scale.Add(new Item("4", "Multiple choice 1-3", String.Empty, false));
            scale.Add(new Item("5", "Slider 1-5", String.Empty, false));
            scale.Add(new Item("6", "Quadrant", String.Empty, false));

            securityQuestion = new List<Item>();

            securityQuestion.Add(new Item("0", String.Empty, String.Empty, false));
            securityQuestion.Add(new Item("1", "In what city or town does your nearest sibling live?", String.Empty, false));
            securityQuestion.Add(new Item("2", "What was your maternal grandfather's first name?", String.Empty, false));
            securityQuestion.Add(new Item("3", "What is the name of the first beach you visited?", String.Empty, false));
            securityQuestion.Add(new Item("4", "In what city or town did you meet your spouse or partner?", String.Empty, false));
            securityQuestion.Add(new Item("5", "What was the make and model of your first car?", String.Empty, false));

            subscriberType = new List<Item>();

            subscriberType.Add(new Item("1", "Consultant", "1", true)); // Old partner
            subscriberType.Add(new Item("3", "To improve my own business", "0", false)); // Business owner
            subscriberType.Add(new Item("5", "Principal Consultant", "3", false)); // Old premium partner
            subscriberType.Add(new Item("4", "Professional Partner", "2", false));

            invoiceStatus = new List<Item>();

            invoiceStatus.Add(new Item("1", "Calculated", String.Empty, true)); // Send email in next run
            invoiceStatus.Add(new Item("2", "Sent", String.Empty, false));
            invoiceStatus.Add(new Item("3", "Manual", String.Empty, false)); // Being processed manually, e.g. by print and post
            invoiceStatus.Add(new Item("4", "Paid", String.Empty, false));
            invoiceStatus.Add(new Item("5", "Cancelled", String.Empty, false)); // A new invoice will be produced
            invoiceStatus.Add(new Item("6", "Free", String.Empty, false)); // Treat as paid, no new invoice will be produced
            invoiceStatus.Add(new Item("7", "Carried", String.Empty, false)); // Treat as paid, no new invoice will be produced

            permissions = new List<Item>();

            permissions.Add(new Item("1", "No Access", String.Empty, true));
            permissions.Add(new Item("2", "Read", String.Empty, false));
            permissions.Add(new Item("3", "Write", String.Empty, false));

            blockchain = new List<Item>();

            blockchain.Add(new Item("0", "None", String.Empty, true));
            blockchain.Add(new Item("1", "Auditable", String.Empty, false));
            blockchain.Add(new Item("2", "History", String.Empty, false));
            blockchain.Add(new Item("3", "Both", String.Empty, false));

            title = new List<Item>();

            title.Add(new Item("1", "Mr.", String.Empty, true));
            title.Add(new Item("2", "Miss", String.Empty, false));
            title.Add(new Item("3", "Mrs.", String.Empty, false));
            title.Add(new Item("4", "Ms.", String.Empty, false));
            title.Add(new Item("5", "Dr.", String.Empty, false));
            title.Add(new Item("7", "Capt.", String.Empty, false));
            title.Add(new Item("6", "Other", String.Empty, false));

            sex = new List<Item>();

            sex.Add(new Item("1", "Male", String.Empty, true));
            sex.Add(new Item("2", "Female", String.Empty, false));
            sex.Add(new Item("3", "Other", String.Empty, false));
            sex.Add(new Item("4", "Prefer not to say", String.Empty, false));

            contractType = new List<Item>();

            contractType.Add(new Item("1", "Full Time", String.Empty, true));
            contractType.Add(new Item("2", "Part Time", String.Empty, false));
            contractType.Add(new Item("3", "Consultant", String.Empty, false));
            contractType.Add(new Item("4", "Temporary", String.Empty, false));
            contractType.Add(new Item("5", "Other", String.Empty, false));

            maritalStatus = new List<Item>();

            maritalStatus.Add(new Item(String.Empty, String.Empty, String.Empty, true));
            maritalStatus.Add(new Item("1", "Single", String.Empty, false));
            maritalStatus.Add(new Item("2", "Married", String.Empty, false));
            maritalStatus.Add(new Item("3", "Divorced", String.Empty, false));
            maritalStatus.Add(new Item("4", "Widowed", String.Empty, false));
            maritalStatus.Add(new Item("5", "Cohabiting", String.Empty, false));
            maritalStatus.Add(new Item("6", "Civil Partnership", String.Empty, false));
            maritalStatus.Add(new Item("7", "Other", String.Empty, false));

            relationship = new List<Item>();

            relationship.Add(new Item(String.Empty, String.Empty, String.Empty, true));
            relationship.Add(new Item("1", "Parent", String.Empty, false));
            relationship.Add(new Item("2", "Guardian", String.Empty, false));
            relationship.Add(new Item("3", "Spouse", String.Empty, false));
            relationship.Add(new Item("4", "Partner", String.Empty, false));
            relationship.Add(new Item("5", "Sibling", String.Empty, false));
            relationship.Add(new Item("6", "Child", String.Empty, false));
            relationship.Add(new Item("7", "Colleague", String.Empty, false));
            relationship.Add(new Item("8", "Friend", String.Empty, false));
            relationship.Add(new Item("9", "Other", String.Empty, false));
        }

        public static string GetString(int stringType, string inString)
        {
            string outString = String.Empty; // "<span style='color: Orange'>?</span>";

            try
            {
                if (Relationship == null) Initialise();

                if (inString.Length == 0) return inString;

                switch (stringType)
                {
                    case (int)StringType.LocationType:
                        {
                            outString = LocationType.FindLast(delegate (Item i) { return i.Value == inString; }).Text;
                            break;
                        }
                    case (int)StringType.Direction:
                        {
                            outString = Direction.FindLast(delegate (Item i) { return i.Value == inString; }).Text;
                            break;
                        }
                    case (int)StringType.Sector:
                        {
                            outString = Sector.FindLast(delegate (Item i) { return i.Value == inString; }).Text;
                            break;
                        }
                    case (int)StringType.InvoiceStatus:
                        {
                            outString = InvoiceStatus.FindLast(delegate (Item i) { return i.Value == inString; }).Text;
                            break;
                        }
                    case (int)StringType.SecurityQuestion:
                        {
                            outString = SecurityQuestion.FindLast(delegate (Item i) { return i.Value == inString; }).Text;
                            break;
                        }
                    case (int)StringType.SubscriberType:
                        {
                            outString = SubscriberType.FindLast(delegate (Item i) { return i.Value == inString; }).Text;
                            break;
                        }
                    case (int)StringType.Sex:
                        {
                            outString = Sex.FindLast(delegate (Item i) { return i.Value == inString; }).Text;
                            break;
                        }
                    case (int)StringType.Title:
                        {
                            outString = Title.FindLast(delegate (Item i) { return i.Value == inString; }).Text;
                            break;
                        }
                    case (int)StringType.Status:
                        {
                            outString = Status.FindLast(delegate (Item i) { return i.Value == inString; }).Text;
                            break;
                        }
                    case (int)StringType.ContractType:
                        {
                            outString = ContractType.FindLast(delegate (Item i) { return i.Value == inString; }).Text;
                            break;
                        }
                    case (int)StringType.MaritalStatus:
                        {
                            outString = MaritalStatus.FindLast(delegate (Item i) { return i.Value == inString; }).Text;
                            break;
                        }
                    case (int)StringType.Relationship:
                        {
                            outString = Relationship.FindLast(delegate (Item i) { return i.Value == inString; }).Text;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }

            return outString;
        }
    }
}
