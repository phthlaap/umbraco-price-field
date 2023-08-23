using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace PriceField.Extensions
{
    public class PriceFieldExtensions
    {
        
        /**
         * Print the price field to HTML tag with configuration.
         * Example:
         *   @{
         *      dynamic dataType = Model.ContentType.GetPropertyType("productPrice").DataType;
         *      dynamic value = Model.Value("productPrice");
         *    }
         *    @PriceFieldExtensions.Format(value, dataType)
         */
        public static IHtmlContent Format(string value, PublishedDataType dataType, CultureInfo cultureInfo = null)
        {
            Dictionary<string, object> configuration = (Dictionary<string, object>)dataType.Configuration;
            dynamic currencySymbol, currencySymbolPosition, isCurrencyEnabled;
            configuration.TryGetValue("currencySymbol", out currencySymbol);
            configuration.TryGetValue("currencySymbolPosition", out currencySymbolPosition);
            configuration.TryGetValue("isCurrencyEnabled", out isCurrencyEnabled);
            decimal number = decimal.Parse(value);
            
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass("card-price");
            var priceTag = new TagBuilder("span");
            priceTag.AddCssClass("price");
            if (cultureInfo == null)
            {
                cultureInfo = new CultureInfo("is-IS");
            }
            priceTag.InnerHtml.Append(number.ToString("N0", cultureInfo));
            var currencyTag = new TagBuilder("span");
            currencyTag.AddCssClass("currency");
            currencyTag.InnerHtml.Append(currencySymbol);
            
            if (currencySymbolPosition == "After")
            {
                tagBuilder.InnerHtml.AppendHtml(priceTag.ToHtmlString());
                if (isCurrencyEnabled == "1")
                {
                    tagBuilder.InnerHtml.AppendHtml(currencyTag.ToHtmlString());
                }
            }
            else
            {
                if (isCurrencyEnabled == "1")
                {
                    tagBuilder.InnerHtml.AppendHtml(currencyTag.ToHtmlString());
                }
                tagBuilder.InnerHtml.AppendHtml(priceTag.ToHtmlString());
            }
            
            return tagBuilder;
        }
    }
};

