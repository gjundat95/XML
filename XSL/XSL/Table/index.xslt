<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">

    <xsl:variable name="xxx" select="/*/bloggers/name[@first = 'Tinh']/@bloggerId"></xsl:variable>
    <xsl:value-of select="/*/blogs/url[@bloggerId = $xxx]"/>
   
  </xsl:template>
</xsl:stylesheet>
