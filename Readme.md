<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128609769/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3402)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/BulletedListExample/Form1.cs) (VB: [Form1.vb](./VB/BulletedListExample/Form1.vb))
* [Program.cs](./CS/BulletedListExample/Program.cs) (VB: [Program.vb](./VB/BulletedListExample/Program.vb))
<!-- default file list end -->
# How to create bulleted list in code


<p>This example illustrates how to create standard bulleted list in code. </p><p>First we add a new <a href="http://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraRichEditAPINativeAbstractNumberingListtopic"><u>AbstractNumberingList</u></a> to the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraRichEditAPINativeDocument_AbstractNumberingListstopic"><u>Document.AbstractNumberingLists</u></a> collection.<br />
Then we specify a <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraRichEditAPINativeNumberingListBase_NumberingTypetopic"><u>NumberingType</u></a> property so it equals the <strong>NumberingType.Bullet</strong> value.<br />
For each <a href="http://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraRichEditAPINativeListLeveltopic"><u>ListLevel</u></a> we specify the paragraph indentation, picture numbering symbol and font. The <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraRichEditAPINativeListLevelProperties_NumberingFormattopic"><u>NumberingFormat</u></a> should be set to <strong>NumberingFormat.Bullet</strong>.<br />
Create a numbering list definition that will be applied to the paragraphs in the document. To accomplish this, use the <strong>Add </strong>method of the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraRichEditAPINativeDocument_NumberingListstopic"><u>NumberingList collection.</u></a> The parameter is the index of an abstract numbering list created before.<br />
To include a paragraph in a bulleted list, set the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraRichEditAPINativeParagraph_ListIndextopic"><u>ListIndex</u></a> property of a paragraph to the index of a list in the document and specify the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraRichEditAPINativeParagraph_ListLeveltopic"><u>ListLevel</u></a> property.</p>

<br/>


