$(document).ready(function () {
    $.ajax({
        url: '/TodoDetails/tabView',
        success: function (result) {
            $('#tabView').html(result);
        }
    });
});
$('#Description').val('');
return false;

//this js helps to load the document and ajax will sends a req to url and that url returns the partial view that 
//builds the table