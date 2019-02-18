$(document).ready(function (){
    $('.ActiveCheck').change(function () {
        var self = $(this);
        var id = self.attr('id');
        var value = self.is(':checked');

        $.ajax({
            url: '/TodoDetails/AjaxEdit',
            data:
            {
                id: id,
                value: value
            },
            type: 'POST',
            success: function (result)
            {
                $('#tabView').html(result);
            }
        });

    });
})