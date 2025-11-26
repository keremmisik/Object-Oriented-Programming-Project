<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SistemLoglari.aspx.cs" Inherits="_241613010_Kerem_Isik_NtpProje.Admin.SistemLoglari" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .log-error { color: red; font-weight: bold; }
        .log-info { color: green; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2>Sistem Log Kayıtları</h2>
    <p>Sistemde gerçekleşen işlemlerin ve hataların kaydı aşağıdadır.</p>

    <asp:Button ID="btnClearLogs" runat="server" Text="🗑️ Logları Temizle" 
        OnClick="btnClearLogs_Click" 
        OnClientClick="return confirm('Tüm log kayıtları silinecek. Emin misiniz?');" 
        style="background-color:#e74c3c; color:white; padding:10px; border:none; cursor:pointer; margin-bottom:20px;" />

    <asp:GridView ID="gvLogs" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="10" GridLines="Horizontal" BorderStyle="None">
        <HeaderStyle BackColor="#34495e" ForeColor="White" HorizontalAlign="Left" />
        <AlternatingRowStyle BackColor="#f9f9f9" />
        
        <Columns>
            <asp:BoundField DataField="Date" HeaderText="Tarih" DataFormatString="{0:dd.MM.yyyy HH:mm:ss}" ItemStyle-Width="150px" />
            
            <asp:TemplateField HeaderText="Seviye" ItemStyle-Width="80px">
                <ItemTemplate>
                    <span class='<%# Eval("Level").ToString() == "ERROR" ? "log-error" : "log-info" %>'>
                        <%# Eval("Level") %>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="Source" HeaderText="Kaynak (Metot)" ItemStyle-Width="250px" ItemStyle-Font-Italic="true" />
            <asp:BoundField DataField="Message" HeaderText="Mesaj" />
        </Columns>
    </asp:GridView>

</asp:Content>
