$(function () {
    jQuery.validator.addMethod('zipvalidattribute', function (value, element, params) {
        var zips = ["8000",
            "8260",
            "8270",
            "8700",
            "7500"];
        for (var i = 0; i < zips.length; i++) {
            if (zips[i] === value) {
                return true;
            }
        }
        return false;
      
    }, '');

    //we need to specify the key for the agecheckattribute that we are
    //using.
    jQuery.validator.unobtrusive.adapters.add('zipvalidattribute', function (options) {
        options.rules['zipvalidattribute'] = {};
        options.messages['zipvalidattribute'] = options.message;
    });

}(jQuery));