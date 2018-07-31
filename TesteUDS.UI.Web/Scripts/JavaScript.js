function preencheEdit() {
    var tr = $('table tr:not(:first-child)');
    tr.on('click', function () {
        var self = this;
        tr.each(function () {
            if (this === self) $(this).toggleClass('colorir');
            else $(this).removeClass('colorir');
        })
    });
}