<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="jsgrid_test.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div id="jsGrid"></div>
<%--    <script src="scripts/forms/Default.js"></script>--%>
    <script type="text/javascript">
        $("#jsGrid").jsGrid({
            width: "100%",

            inserting: true,
            editing: true,
            filtering: true,
            sorting: true,
            paging: true,

            controller: {
                loadData: function () {
                    $.ajax({
                        type: "GET",
                        contentType: "application/json",
                        url: "Default.aspx/GetInvList"
                    }).done(function (response) {
                        console.log(response);
                    });
                },

                insertItem: function () { alert('insert') },
                updateItem: function (item) { alert(item.colOrgJed) },
                deleteItem: function () { alert('brisanje') }
            },
            fields: [
                { name: "colDokument", type: "text", visible: false },
                { name: "colLocName", title: "Naziv", type: "text" },
                { name: "colItmPrcs", title: "Naziv", type: "text" },
                { name: "colItmTotl", title: "Naziv", type: "text" },
                { name: "colPrcPrcs", title: "Naziv", type: "text" },
                { name: "colFirstScn", title: "Naziv", type: "text" },
                { name: "colLastScn", title: "Naziv", type: "text" },
                { type: "control" }
            ]
        });
    </script>
</asp:Content>
