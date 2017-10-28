// Write your JavaScript code.
$(function () {
    $('#bs-example-navbar-collapse-1')
        .on('shown.bs.collapse', function () {
            //토글버튼 눌렸을때
            $('#navbar-hamburger').addClass('hidden');
            $('#navbar-close').removeClass('hidden');
            $('#navbar-close').parent('button').addClass('navbar-toggle-clicked');
            //$('.dropdown').addClass('open');
        })
        .on('hidden.bs.collapse', function () {
            //토글버튼 안 눌렸을때
            $('#navbar-hamburger').removeClass('hidden');
            $('#navbar-close').addClass('hidden');
            $('#navbar-close').parent('button').removeClass('navbar-toggle-clicked');
            //$('.dropdown').removeClass('open');
        });


    //Close the dropdowns in case the window is resized
    //$(window).on('resize', function () {
    //    if ($(window).width() < 767) {
    //        $('.dropdown-menu').addClass('in');
    //    }
    //});

    $('.dropdown').hover(function () {
        $('.dropdown-toggle', this).trigger('click');
    });
});

$(".editor").trumbowyg({
    lang: 'ko',
    btnsDef: {
        image: {
            dropdown: ['insertImage', 'upload'],
            ico:'insertImage'
        }
    },
    btns: [
        ['viewHTML'],
        ['undo', 'redo'],
        ['bold', 'italic', 'strikethrough', 'underline'],
        ['formatting'],
        ['superscript', 'subscript'],
        ['link'],
        'image',
        'btnGrp-justify',
        'btnGrp-lists',
        ['horizontalRule'],
        ['removeformat'],
        ['fullscreen']
    ]
});