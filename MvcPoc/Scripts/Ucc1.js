$(document).ready(function () {

    $(this).find('[id^="Remove-Debtor-"]').click(function (e) {
        var removeDebtorIndex = this.id.substring(this.id.lastIndexOf('-') + 1);
        $("#Ucc1Debtors_" + removeDebtorIndex + "__IsRemoved").val("true");
        $("#debtor-section-" + removeDebtorIndex).hide();
    });

});
