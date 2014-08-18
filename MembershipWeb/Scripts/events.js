$(document).ready(function() {
    $("a.submit").click(function(event) {
        event.preventDefault();
        var formId = $(this).attr("data-formid");
        formId && $("form#" + formId).submit();        
    });
});