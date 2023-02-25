<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BookStore.pages.Books" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Don chalino</title>
</head>
<body style="height: 412px">
    <form id="form1" runat="server">
        <div style="height: 65px">
            <asp:Label ID="Label1" runat="server" Text="LIBRERIA DE DON CHALINO"></asp:Label>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="ISBN" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None" Height="346px" Width="1497px">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" ReadOnly="True" SortExpression="ISBN" />
                    <asp:BoundField DataField="TITULO" HeaderText="TITULO" SortExpression="TITULO" />
                    <asp:BoundField DataField="AUTOR" HeaderText="AUTOR" SortExpression="AUTOR" />
                    <asp:BoundField DataField="SINOPSIS" HeaderText="SINOPSIS" SortExpression="SINOPSIS" />
                    <asp:BoundField DataField="EDICION" HeaderText="EDICION" SortExpression="EDICION" />
                    <asp:BoundField DataField="ANIO_PUBLICACION" HeaderText="ANIO_PUBLICACION" SortExpression="ANIO_PUBLICACION" />
                    <asp:BoundField DataField="PAIS_PUBLICACION" HeaderText="PAIS_PUBLICACION" SortExpression="PAIS_PUBLICACION" />
                </Columns>
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PracticaConnectionString %>" SelectCommand="SELECT * FROM [BOOKS]"></asp:SqlDataSource>
            <br />
        </div>
    <p>
        &nbsp;</p>
        <p>
            <asp:Button ID="btnAgregar" runat="server" EnableTheming="False" Height="81px" Text="Agregar" Width="249px" OnClick="btnAgregar_Click" />
        </p>
    </form>
    </body>
</html>
