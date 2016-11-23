<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <xsl:param name="classid">
      <xsl:for-each select="document('a.xml')/Xml/Classes/Class">
        <xsl:if test="@Name='PHYSICS101' ">
          <xsl:value-of select="@ClassId"/>
        </xsl:if>
      </xsl:for-each>
    </xsl:param>

    <xsl:value-of select="$classid"/>
    
    <xsl:for-each select="Xml/Students/Student">
      <xsl:if test="@ClassId = $classid">
        <xsl:value-of select="@ClassId"/>
        <xsl:value-of select="@Name"/>
      </xsl:if>
    </xsl:for-each>
    
  </xsl:template>
  
</xsl:stylesheet>
