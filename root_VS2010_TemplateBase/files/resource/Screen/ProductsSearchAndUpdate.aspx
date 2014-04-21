﻿<%@ Page Language="C#" MasterPageFile="~/Aspx/Common/testBlankScreen.master" AutoEventWireup="true" CodeFile="ProductsSearchAndUpdate.aspx.cs" Inherits="ProductsSearchAndUpdate" Title="ProductsSearchAndUpdate" %>
<%@ Register Assembly="CustomControl" Namespace="Touryo.Infrastructure.CustomControl" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_A" Runat="Server">
    <!-- Copyright (C) 2007,2014 Hitachi Solutions,Ltd. -->
    
    データアクセス制御クラス（データプロバイダ）を選択<br />
    <cc1:WebCustomDropDownList ID="ddlDap" runat="server">
        <asp:ListItem Value="SQL">SQL Server / SQL Client</asp:ListItem>
        <asp:ListItem Value="ODP">Oracle / ODP.NET</asp:ListItem>
    </cc1:WebCustomDropDownList><br />

       <table width="100%">
        <tr>
            <td>
                AND = 条件<br/>
                <table>
                    <tr>
                        <td>ProductID</td>
                        <td><cc1:WebCustomTextBox ID="txtProductID_And" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>ProductName</td>
                        <td><cc1:WebCustomTextBox ID="txtProductName_And" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>SupplierID</td>
                        <td><cc1:WebCustomTextBox ID="txtSupplierID_And" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>CategoryID</td>
                        <td><cc1:WebCustomTextBox ID="txtCategoryID_And" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>QuantityPerUnit</td>
                        <td><cc1:WebCustomTextBox ID="txtQuantityPerUnit_And" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>UnitPrice</td>
                        <td><cc1:WebCustomTextBox ID="txtUnitPrice_And" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>UnitsInStock</td>
                        <td><cc1:WebCustomTextBox ID="txtUnitsInStock_And" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>UnitsOnOrder</td>
                        <td><cc1:WebCustomTextBox ID="txtUnitsOnOrder_And" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>ReorderLevel</td>
                        <td><cc1:WebCustomTextBox ID="txtReorderLevel_And" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>Discontinued</td>
                        <td><cc1:WebCustomTextBox ID="txtDiscontinued_And" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                </table>
                <br/>
                AND Like 条件<br/>
                <table>                    
                    <tr>
                        <td>ProductID</td>
                        <td><cc1:WebCustomTextBox ID="txtProductID_And_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>ProductName</td>
                        <td><cc1:WebCustomTextBox ID="txtProductName_And_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>SupplierID</td>
                        <td><cc1:WebCustomTextBox ID="txtSupplierID_And_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>CategoryID</td>
                        <td><cc1:WebCustomTextBox ID="txtCategoryID_And_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>QuantityPerUnit</td>
                        <td><cc1:WebCustomTextBox ID="txtQuantityPerUnit_And_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>UnitPrice</td>
                        <td><cc1:WebCustomTextBox ID="txtUnitPrice_And_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>UnitsInStock</td>
                        <td><cc1:WebCustomTextBox ID="txtUnitsInStock_And_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>UnitsOnOrder</td>
                        <td><cc1:WebCustomTextBox ID="txtUnitsOnOrder_And_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>ReorderLevel</td>
                        <td><cc1:WebCustomTextBox ID="txtReorderLevel_And_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>Discontinued</td>
                        <td><cc1:WebCustomTextBox ID="txtDiscontinued_And_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                </table>
            </td>
            <td>
                OR = 条件<br/>
                <table>
                    <tr>
                        <td>ProductID</td>
                        <td><asp:TextBox ID="txtProductID_OR" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>ProductName</td>
                        <td><cc1:WebCustomTextBox ID="txtProductName_OR" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>SupplierID</td>
                        <td><cc1:WebCustomTextBox ID="txtSupplierID_OR" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>CategoryID</td>
                        <td><cc1:WebCustomTextBox ID="txtCategoryID_OR" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>QuantityPerUnit</td>
                        <td><cc1:WebCustomTextBox ID="txtQuantityPerUnit_OR" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>UnitPrice</td>
                        <td><cc1:WebCustomTextBox ID="txtUnitPrice_OR" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>UnitsInStock</td>
                        <td><cc1:WebCustomTextBox ID="txtUnitsInStock_OR" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>UnitsOnOrder</td>
                        <td><cc1:WebCustomTextBox ID="txtUnitsOnOrder_OR" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>ReorderLevel</td>
                        <td><cc1:WebCustomTextBox ID="txtReorderLevel_OR" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>Discontinued</td>
                        <td><cc1:WebCustomTextBox ID="txtDiscontinued_OR" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                </table>
                <br/>
                OR Like 条件<br/>
                <table>
                    <tr>
                        <td>ProductID</td>
                        <td><cc1:WebCustomTextBox ID="txtProductID_OR_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>ProductName</td>
                        <td><cc1:WebCustomTextBox ID="txtProductName_OR_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>SupplierID</td>
                        <td><cc1:WebCustomTextBox ID="txtSupplierID_OR_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>CategoryID</td>
                        <td><cc1:WebCustomTextBox ID="txtCategoryID_OR_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>QuantityPerUnit</td>
                        <td><cc1:WebCustomTextBox ID="txtQuantityPerUnit_OR_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>UnitPrice</td>
                        <td><cc1:WebCustomTextBox ID="txtUnitPrice_OR_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>UnitsInStock</td>
                        <td><cc1:WebCustomTextBox ID="txtUnitsInStock_OR_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>UnitsOnOrder</td>
                        <td><cc1:WebCustomTextBox ID="txtUnitsOnOrder_OR_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>ReorderLevel</td>
                        <td><cc1:WebCustomTextBox ID="txtReorderLevel_OR_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                    <tr>
                        <td>Discontinued</td>
                        <td><cc1:WebCustomTextBox ID="txtDiscontinued_OR_Like" runat="server"></cc1:WebCustomTextBox></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <asp:Button ID="btnSearch" runat="server" Text="上記の条件で検索" />
    <asp:Button ID="btnInsert" runat="server" Text="レコードを追加する。" />
    <asp:Button ID="btnBatUpd" runat="server" Text="下記の結果セットをバッチ更新する" />
        
    <asp:GridView ID="gvwGridView1" runat="server" 
        AutoGenerateColumns="False" DataKeyNames="ProductID"
        AllowPaging="True" AllowSorting="True" PageSize="30"
        Width="100%" BorderWidth="1px">
        
        <HeaderStyle BackColor="darkturquoise" />
        <EditRowStyle BackColor="LightYellow" />
       	    
        <Columns>
            <asp:ButtonField CommandName="Delete" Text="削除"/>
            <asp:ButtonField CommandName="Update" Text="更新"/>

            <asp:TemplateField SortExpression="ProductID">
                <ItemTemplate>
                    <asp:TextBox ReadOnly="true" BackColor="lightgray" ID="txtProductID" runat="server" Text='<%# Bind("ProductID") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="ProductName">
                <ItemTemplate>
                    <asp:TextBox ID="txtProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="SupplierID">
                <ItemTemplate>
                    <asp:TextBox ID="txtSupplierID" runat="server" Text='<%# Bind("SupplierID") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="CategoryID">
                <ItemTemplate>
                    <asp:TextBox ID="txtCategoryID" runat="server" Text='<%# Bind("CategoryID") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="QuantityPerUnit">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantityPerUnit" runat="server" Text='<%# Bind("QuantityPerUnit") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="UnitPrice">
                <ItemTemplate>
                    <asp:TextBox ID="txtUnitPrice" runat="server" Text='<%# Bind("UnitPrice") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="UnitsInStock">
                <ItemTemplate>
                    <asp:TextBox ID="txtUnitsInStock" runat="server" Text='<%# Bind("UnitsInStock") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="UnitsOnOrder">
                <ItemTemplate>
                    <asp:TextBox ID="txtUnitsOnOrder" runat="server" Text='<%# Bind("UnitsOnOrder") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="ReorderLevel">
                <ItemTemplate>
                    <asp:TextBox ID="txtReorderLevel" runat="server" Text='<%# Bind("ReorderLevel") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="Discontinued">
                <ItemTemplate>
                    <asp:TextBox ID="txtDiscontinued" runat="server" Text='<%# Bind("Discontinued") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
            </asp:GridView>

    <asp:ObjectDataSource ID="ObjectDataSource1"
        runat="server" EnablePaging="True"
        TypeName="ProductsTableAdapter" 
        SelectCountMethod="SelectCountMethod"
        SelectMethod="SelectMethod"
        MaximumRowsParameterName="maximumRows"
        StartRowIndexParameterName="startRowIndex">
    </asp:ObjectDataSource>

 </asp:Content>
