<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" MasterPageFile="~/master.Master" Inherits="WoWSimulator._default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label runat="server" ID="error" Visible="false" ForeColor="Red" /><br />

    <%--Body Div--%>
    <div runat="server" style="overflow: auto; width: 100%; vertical-align: text-top; top: 0px; background-color: white">
        <table>
            <tr>
                <td>
                    <asp:Label ID="ActivePlayerCountLabel" Text="Player Count:" runat="server" Font-Size="Larger" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="BTSearchUpdate" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <Triggers>

                        </Triggers>
                        <ContentTemplate>
                            <div>
                                <table class="greenTable">
                                    <tr>
                                        <th class="greenTableHeader" style="width: 1000px">Battletag</th>
                                    </tr>
                                </table>
                            </div>

                            <asp:Panel ID="viewPanel" Width="100%" runat="server" Height="312px" ScrollBars="Auto">
                                <asp:ListView ID="BattletagLookupListview" runat="server">

                                    <LayoutTemplate>
                                        <div>
                                            <table class="greenTable">
                                                <tr id="itemPlaceholder" runat="server"></tr>
                                            </table>
                                        </div>
                                    </LayoutTemplate>

                                    <ItemTemplate>
                                        <tr>
                                            <td class="gridcell" style="width: 1000px;">
                                                <asp:Label ID="BattletagLabel" runat="server" Text='<%# Eval("Battletag") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>

                                    <AlternatingItemTemplate>
                                        <tr>
                                            <td class="grid_cell_alternating" style="width: 1000px;">
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

            <tr>
                <td>
                    <br />
                    <asp:UpdatePanel ID="realmUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <Triggers>

                        </Triggers>
                        <ContentTemplate>
                            <div>
                                <table class="greenTable">
                                    <tr>
                                        <th class="greenTableHeader" style="width: 500px">Realm</th>
                                        <th class="greenTableHeader" style="width: 500px">Players</th>
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

                                            <td class="gridcell" style="width: 500px">
                                                <asp:Label ID="RealmLabel" runat="server" Text='<%# Eval("Realm") %>' />
                                            </td>

                                            <td class="gridcell" style="width: 500px">
                                                <asp:Label ID="PlayerCountLabel" runat="server" Text='<%# Eval("PlayerCount") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>

                                    <AlternatingItemTemplate>
                                        <tr>
                                            <td class="grid_cell_alternating" style="width: 500px">
                                                <asp:Label ID="RealmLabel" runat="server" Text='<%# Eval("Realm") %>' />
                                            </td>

                                            <td class="grid_cell_alternating" style="width: 500px">
                                                <asp:Label ID="PlayerCountLabel" runat="server" Text='<%# Eval("PlayerCount") %>' />
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
