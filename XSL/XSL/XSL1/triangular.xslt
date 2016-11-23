<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <!--<xsl:variable name="a" select="a"/>
    <xsl:variable name="b" select="b"/>
    <xsl:variable name="c" select="c"/>
    Chu vi la:
    <xsl:value-of select="a+b+c"/>-->

    <xsl:variable name="the_max">
      <xsl:for-each select="/triangulars/triangular/n">
        <xsl:sort data-type="number" order="descending"/>
        <xsl:if test="position()=1">
          <xsl:value-of select="."/>
        </xsl:if>
      </xsl:for-each>
    </xsl:variable>

    <xsl:value-of select="$the_max"/>
    
  </xsl:template>
</xsl:stylesheet>
