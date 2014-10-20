<?xml version = "1.0"?>
<!-- Solution: nutrition.xsl -->
<!-- Transformation of nutrition information into XHTML -->

<xsl:stylesheet version = "1.0" xmlns = "http://www.w3.org/1999/xhtml"
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">
    <!-- write XML declaration and DOCTYPE DTD information -->
   <xsl:output method = "xml" omit-xml-declaration = "no"
      doctype-system = "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"
      doctype-public = "-//W3C//DTD XHTML 1.1//EN" />
     <!-- match document root -->
      <xsl:template match = "/">
         <html>
            <xsl:apply-templates/>
         </html>
      </xsl:template>
      <!--match nutrtion -->
      <xsl:template match="nutrition">
      	<head>
      		<title>
      			Product name: <xsl:value-of select="@productname"/>
      			<!-- <xsl:value-of select="@productname"/>  -->     		
      		</title>
      	</head>
      	<body>
      		<h1 style = "color:blue"><xsl:value-of select="@productname"/></h1>
      	</body>
      </xsl:template>

</xsl:stylesheet>
