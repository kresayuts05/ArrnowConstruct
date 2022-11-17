using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Constants
{
    public static class ModelConstraints
    {
        public static class UserConstants
        {
            public const int FirstNameMaxLength = 50;
            public const int FirstNameMinLength = 2;

            public const int LastNameMaxLength = 50;
            public const int LastNameMinLength = 2;

            public const int AddressMaxLength = 100;
            public const int AddressMinLength = 5;

            public const int CityMaxLength = 169;
            public const int CityMinLength = 1;

            public const int CountryMaxLength = 56;
            public const int CountryMinLength = 4;

            public const int EmailMaxLength = 50;
            public const int EmailMinLength = 10;
        }

        public static class SiteConstants
        {
            public const string StartingPriceMaxValue = "100000";
            public const string StartingPriceMinValue = "1000";
        }

        public static class RoomConstants
        {
            public const string AreaMaxValue = "100000";
            public const string AreaMinValue = "1000";
        }

        public static class ReviewImageConstants
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 50;
        }
        public static class ReviewCommentConstants
        {
            public const int FullUserNameMaxLength = 110;
            public const int FullUserNameMinLength = 5;

            public const int EmailMaxLength = 50;
            public const int EmailMinLength = 10;
        }
        public static class ReviewConstants
        {
            public const string RatingMaxValue = "5";
            public const string RatingMinValue = "0";

            public const int DescriptionMaxLength = 1000;
            public const int DescriptionMinLength = 20;
        }
        public static class RequestConstants
        {
            public const string RoomMaxCount = "15";
            public const string RoomMinCount = "1";

            public const int DescriptionMaxLength = 1000;
            public const int DescriptionMinLength = 20;

            public const string BudgetMaxValue = "100000";
            public const string BudgetMinValue = "1000";
        }
        public static class PostImageConstants
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 50;
        }
        public static class PostCommentConstants
        {
            public const int FullUserNameMaxLength = 110;
            public const int FullUserNameMinLength = 5;

            public const int EmailMaxLength = 50;
            public const int EmailMinLength = 10;
        }
        public static class PostConstants
        {
            public const int DescriptionMaxLength = 1000;
            public const int DescriptionMinLength = 20;

            public const int ShortContentMaxLength = 50;
            public const int ShortContentMinLength = 10;

            public const int TiteMaxLength = 25;
            public const int TitleMinLength = 2;
        }
        public static class ConstructorConstants
        {
            public const string SalaryMaxValue = "100000";
            public const string SalaryMinValue = "1000";
        }
    }
}
