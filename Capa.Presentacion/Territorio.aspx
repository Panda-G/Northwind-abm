<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Territorio.aspx.cs" Inherits="Capa.Presentacion.Territorio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Northwind [ A-B-M ]</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="col-lg-12">
                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" class="table table-striped" >
                    <RowStyle BackColor="#EFF3FB" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowCancelButton="False" ShowSelectButton="True" ControlStyle-CssClass="btn btn-info btn-sm" ItemStyle-HorizontalAlign="Center" />
                    </Columns>
                </asp:GridView>

                <div class="form-group col-lg-4 text-">
                    <asp:Label ID="lblTerritorioID" runat="server" Text="ID Territorio ( * )" Font-Size="Large"></asp:Label>
                    <asp:TextBox ID="txtTerritorioID" runat="server" Width="120px" CssClass="auto-style1"></asp:TextBox>
                </div>
                <div class="form-group col-lg-6">
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion ( * )" Font-Size="Large"></asp:Label>
                    <asp:TextBox ID="txtDescripcion" runat="server" Width="198px"></asp:TextBox>
                </div>
                <div class="form-group col-lg-2">
                    <asp:DropDownList ID="ddlRegionID" runat="server" CssClass="auto-style1" Height="27px" Width="60px" AutoPostBack="True" Font-Size="Large">
                        <asp:ListItem Enabled="False">[Seleccionar]</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-12 text-center">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" Font-Size="Large" />
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" Enabled="False" OnClick="btnModificar_Click" Font-Size="Large" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Enabled="False" OnClick="btnEliminar_Click" Font-Size="Large" />
                    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" Visible="False" Font-Size="Large" />
                </div>
                <div>
                    <asp:Label ID="lblDetalles" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
