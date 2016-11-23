<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <!--<xsl:value-of select="book[2]/author"/>
    <xsl:value-of select="author"/>
    <xsl:value-of select="year"/>
    <xsl:value-of select="price"/> //\\-->
    <!--</xsl:for-each>-->
    <xsl:for-each select="root/book">
      <xsl:value-of select="author"/>
      <xsl:value-of select="year"/>
      <xsl:value-of select="price"/>
      <!--<xsl:variable name="var" select="year"/>
      <xsl:if test="year=2001">
        <xsl:value-of select="author"/>
        <xsl:value-of select="year"/>
        <xsl:value-of select="price"/>
      </xsl:if>-->
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>
