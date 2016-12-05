<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="CharacterInfo.aspx.cs" Inherits="WoWSimulator.CharacterInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label runat="server" ID="error" Visible="false" ForeColor="Red" /><br />

    <%--Body Div--%>
    <div runat="server" style="overflow: auto; width: 100%; vertical-align: text-top; top: 0px; background-color: white">
        <table>
            <tr>
                <td>
                    <asp:Label ID="CharacterCountLabel" Text="Total Character Count" Font-Size="Larger" runat="server" />
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
                                        <th class="greenTableHeader" style="width: 200px">Battletag</th>
                                        <th class="greenTableHeader" style="width: 200px">Character</th>
                                        <th class="greenTableHeader" style="width: 200px">Race</th>
                                        <th class="greenTableHeader" style="width: 200px">Level</th>
                                        <th class="greenTableHeader" style="width: 200px">Realm</th>
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
                                            <td class="gridcell" style="width: 200px;">
                                                <asp:Label ID="BattletagLabel" runat="server" Text='<%# Eval("Battletag") %>' />
                                            </td>

                                            <td class="gridcell" style="width: 200px;">
                                                <asp:Label ID="CharacterLabel" runat="server" Text='<%# Eval("Character") %>' />
                                            </td>

                                            <td class="gridcell" style="width: 200px;">
                                                <asp:Label ID="RaceLabel" runat="server" Text='<%# Eval("Race") %>' />
                                            </td>

                                            <td class="gridcell" style="width: 200px;">
                                                <asp:Label ID="LevelLabel" runat="server" Text='<%# Eval("Level") %>' />
                                            </td>

                                            <td class="gridcell" style="width: 200px;">
                                                <asp:Label ID="RealmLabel" runat="server" Text='<%# Eval("Realm") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>

                                    <AlternatingItemTemplate>
                                        <tr>
                                            <td class="grid_cell_alternating" style="width: 200px;">
                                                <asp:Label ID="BattletagLabel" runat="server" Text='<%# Eval("Battletag") %>' />
                                            </td>

                                            <td class="grid_cell_alternating" style="width: 200px;">
                                                <asp:Label ID="CharacterLabel" runat="server" Text='<%# Eval("Character") %>' />
                                            </td>

                                            <td class="grid_cell_alternating" style="width: 200px;">
                                                <asp:Label ID="RaceLabel" runat="server" Text='<%# Eval("Race") %>' />
                                            </td>

                                            <td class="grid_cell_alternating" style="width: 200px;">
                                                <asp:Label ID="LevelLabel" runat="server" Text='<%# Eval("Level") %>' />
                                            </td>

                                            <td class="grid_cell_alternating" style="width: 200px;">
                                                <asp:Label ID="RealmLabel" runat="server" Text='<%# Eval("Realm") %>' />
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
                    <asp:UpdatePanel ID="BattletagLevelUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <Triggers>

                        </Triggers>
                        <ContentTemplate>
                            <div>
                                <table class="greenTable">
                                    <tr>
                                        <th class="greenTableHeader" style="width: 333px">Battletag</th>
                                        <th class="greenTableHeader" style="width: 333px">Average Level</th>
                                        <th class="greenTableHeader" style="width: 333px">Max Level</th>
                                    </tr>
                                </table>
                            </div>

                            <asp:Panel ID="BattletagLevelViewPanel" Width="100%" runat="server" Height="400" ScrollBars="Auto">
                                <asp:ListView ID="BattletagLevelListview" runat="server">

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
                                                <asp:Label ID="BattletagLevelLabel" runat="server" Text='<%# Eval("Battletag") %>' />
                                            </td>

                                            <td class="gridcell" style="width: 333px">
                                                <asp:Label ID="AverageLevelLabel" runat="server" Text='<%# Eval("AverageLevel") %>' />
                                            </td>

                                            <td class="gridcell" style="width: 333px">
                                                <asp:Label ID="MaxLevelLabel" runat="server" Text='<%# Eval("MaxLevel") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>

                                    <AlternatingItemTemplate>
                                        <tr>
                                            <td class="grid_cell_alternating" style="width: 333px">
                                                <asp:Label ID="BattletagLevelLabel" runat="server" Text='<%# Eval("Battletag") %>' />
                                            </td>

                                            <td class="grid_cell_alternating" style="width: 333px">
                                                <asp:Label ID="AverageLevelLabel" runat="server" Text='<%# Eval("AverageLevel") %>' />
                                            </td>

                                            <td class="grid_cell_alternating" style="width: 333px">
                                                <asp:Label ID="MaxLevelLabel" runat="server" Text='<%# Eval("MaxLevel") %>' />
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
