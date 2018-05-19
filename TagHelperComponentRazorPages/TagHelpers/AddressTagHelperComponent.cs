﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperComponentRazorPages.TagHelpers
{
	public class AddressTagHelperComponent : ITagHelperComponent
	{
		string _printableButton = "<button type='button' class='btn btn-info' onclick=\"window.open('https://www.google.com/maps/place/Microsoft+Way,+Redmond,+WA+98052,+USA/@47.6414942,-122.1327809,17z/')\">" +
			                        "<span class='glyphicon glyphicon-road' aria-hidden='true'></span>" +
			                      "</button>";
        
		public int Order => _order;
		private string _markup;
		private int _order;

		public AddressTagHelperComponent(string markup = "", int order = 1)
		{
			_markup = markup;
			_order = 1;
		}

		public void Init(TagHelperContext context) { }

		public async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
			if (string.Equals(context.TagName, "address", StringComparison.OrdinalIgnoreCase) && output.Attributes.ContainsName("printable"))
            {
				var content = await output.GetChildContentAsync();
				output.Content.SetHtmlContent($"<div>{content.GetContent()}<br/>{_markup}</div>{_printableButton}");
            }
        }
	}
}