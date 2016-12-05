<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="RealmInfo.aspx.cs" Inherits="WoWSimulator.RealmInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label runat="server" ID="error" Visible="false" ForeColor="Red" /><br />

    <%--Body Div--%>
    <div runat="server" style="overflow: auto; width: 100%; vertical-align: text-top; top: 0px; background-color: white">
        <table>
            <tr>
                <td>
                    <asp:Label ID="RealmCountLabel" runat="server" Text="Active Realm Count: " Font-Size="Larger" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="realmUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <Triggers>

                        </Triggers>
                        <ContentTemplate>
                            <div>
                                <table class="greenTable">
                                    <tr>
                                        <th class="greenTableHeader" style="width: 200px">Realm</th>
                                        <th class="greenTableHeader" style="width: 200px">Alliance</th>
                                        <th class="greenTableHeader" style="width: 200px">Horde</th>
                                        <th class="greenTableHeader" style="width: 200px">Region</th>
                                        <th class="greenTableHeader" style="width: 200px">Type</th>
                                    </tr>
                                </table>
                            </div>

                            <asp:Panel ID="realmViewPanel" Width="100%" runat="server" Height="400" ScrollBars="Auto">
                                <asp:ListView ID="RealmLookupListview" runat="server">

                                    <LayoutTemplate>
                                        <div>
                                            <table class="greenTable">
                                                <tr id="itemPlaceholder" runat="server"></tr>
                                            </table>
                                        </div>
                                    </LayoutTemplate>

                                    <ItemTemplate>
                                        <tr>
                                            <td class="gridcell" style="width: 200px">
                                                <asp:Label ID="RealmLabel" runat="server" Text='<%# Eval("Realm") %>' />
                                            </td>

                                            <td class="gridcell" style="width: 200px">
                                                <asp:Label ID="AllianceLabel" runat="server" Text='<%# Eval("Alliance") %>' />
                                            </td>

                                            <td class="gridcell" style="width: 200px">
                                                <asp:Label ID="HordeLabel" runat="server" Text='<%# Eval("Horde") %>' />
                                            </td>

                                            <td class="gridcell" style="width: 200px">
                                                <asp:Label ID="Region" runat="server" Text='<%# Eval("Region") %>' />
                                            </td>

                                            <td class="gridcell" style="width: 200px">
                                                <asp:Label ID="Type" runat="server" Text='<%# Eval("Type") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>

                                    <AlternatingItemTemplate>
                                        <tr>
                                            <td class="grid_cell_alternating" style="width: 200px">
                                                <asp:Label ID="RealmLabel" runat="server" Text='<%# Eval("Realm") %>' />
                                            </td>

                                            <td class="grid_cell_alternating" style="width: 200px">
                                                <asp:Label ID="AllianceLabel" runat="server" Text='<%# Eval("Alliance") %>' />
                                            </td>

                                            <td class="grid_cell_alternating" style="width: 200px">
                                                <asp:Label ID="HordeLabel" runat="server" Text='<%# Eval("Horde") %>' />
                                            </td>

                                            <td class="grid_cell_alternating" style="width: 200px">
                                                <asp:Label ID="Region" runat="server" Text='<%# Eval("Region") %>' />
                                            </td>

                                            <td class="grid_cell_alternating" style="width: 200px">
                                                <asp:Label ID="Type" runat="server" Text='<%# Eval("Type") %>' />
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                </asp:ListView>
                            </asp:Panel>


                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
