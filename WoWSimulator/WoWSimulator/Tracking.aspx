<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Tracking.aspx.cs" Inherits="WoWSimulator.Tracking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" ID="error" Visible="false" ForeColor="Red" /><br />

    <%--Body Div--%>
    <div runat="server" style="overflow: auto; width: 100%; vertical-align: text-top; top: 0px; background-color: white">
        <table>
            <tr>
                <td>
                    <asp:UpdatePanel ID="TrackingUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <Triggers>
                            <%--Don't worry about this--%>
                            <%--<asp:AsyncPostBackTrigger ControlID="RealmSearchBox" />--%>
                        </Triggers>
                        <ContentTemplate>
                            <div>
                                <table class="greenTable">
                                    <tr>
                                        <th class="greenTableHeader" style="width: 333px">Email</th>
                                        <th class="greenTableHeader" style="width: 333px">Password</th>
                                        <th class="greenTableHeader" style="width: 333px">Currently Tracked Battletag</th>
                                    </tr>
                                </table>
                            </div>

                            <asp:Panel ID="TrackingViewPanel" Width="100%" runat="server" Height="400" ScrollBars="Auto">
                                <asp:ListView ID="TrackingListview" runat="server">

                                    <LayoutTemplate>
                                        <div>
                                            <table class="greenTable">
                                                <tr id="itemPlaceholder" runat="server"></tr>
                                            </table>
                                        </div>
                                    </LayoutTemplate>

                                    <ItemTemplate>
                                        <tr>
                                            <td class="gridcell" style="width: 333px">
                                                <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                                            </td>

                                            <td class="gridcell" style="width: 333px">
                                                <asp:Label ID="PasswordLabel" runat="server" Text='<%# Eval("Password") %>' />
                                            </td>

                                            <td class="gridcell" style="width: 333px">
                                                <asp:Label ID="BattletagLabel" runat="server" Text='<%# Eval("Battletag") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>

                                    <AlternatingItemTemplate>
                                        <tr>
                                             <td class="grid_cell_alternating" style="width: 333px">
                                                <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                                            </td>

                                            <td class="grid_cell_alternating" style="width: 333px">
                                                <asp:Label ID="PasswordLabel" runat="server" Text='<%# Eval("Password") %>' />
                                            </td>

                                            <td class="grid_cell_alternating" style="width: 333px">
                                                <asp:Label ID="BattletagLabel" runat="server" Text='<%# Eval("Battletag") %>' />
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
