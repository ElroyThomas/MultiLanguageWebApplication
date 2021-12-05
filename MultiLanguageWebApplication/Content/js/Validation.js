var ResponseCode = {
    Success: "Success",
    Error: "Error",
    ModelIsNotValid: "ModelIsNotValid",
    AlreadyExists: "AlreadyExists",
    Failed: "Failed"
};


function ValidateForm(id) {
    var isValid = true;

    $("form#" + id + " :input").each(function () {
        var input = $(this);
        var type = input.prop('type');
        switch (type) {
            case "text":
            case "textarea":
                if (input.data("required")) {
                    var value = input.val().trim() || "";

                    if (value == "") {
                        var message = input.data("required") || "This Field is Required";
                        input.next("span").html(message.toLowerCase());
                        input.css("border-color", "red");
                        isValid = false;

                    }
                    else {
                        input.next("span").html("");
                        input.css("border-color", "");
                    }
                }
                break;
            case "select":
                if (input.data("required")) {
                    var value = input.val() || 0;

                    if (value <= 0) {
                        var message = input.data("required") || "This Field is Required";
                        input.css("border-color", "red");
                        input.next("span").html(message.toLowerCase());
                        isValid = false;
                    }
                    else {
                        input.next("span").html("");
                        input.css("border-color", "");
                    }
                }
                break;
            case "select-one":
                if (input.data("required")) {
                    var value = input.val() || 0;

                    if (value <= 0) {
                        var message = input.data("required") || "This Field is Required";
                        input.css("border-color", "red");
                        input.next("span").html(message.toLowerCase());
                        isValid = false;
                    }
                    else {
                        input.next("span").html("");
                        input.css("border-color", "");
                    }
                }
                break;
            case "file":
                if (input.data("required")) {
                    var value = input.val().trim() || "";

                    if (value == "") {
                        var message = input.data("required") || "This Field is Required";
                        input.parent().parent().find("span").html(message.toLowerCase());
                        input.css("border-color", "red");
                        isValid = false;

                    }
                    else {
                        input.next("span").html("");
                        input.css("border-color", "");
                    }
                }
                break;
            case "number":
                if (input.data("required")) {
                    var value = input.val().trim() || "";

                    if (value == "") {
                        var message = input.data("required") || "This Field is Required";
                        input.next("span").html(message.toLowerCase());
                        input.css("border-color", "red");
                        isValid = false;

                    }
                    else {
                        var isNumberValid = true;
                        if (/^\d+$/.test(input.val())) {
                            var customType = input.data("type");

                            if (customType) {
                                switch (customType) {
                                    case "Positive":
                                        if (input.val() < 0) {
                                            input.next("span").html("please enter positive number");
                                            input.css("border-color", "red");
                                            isValid = false;
                                            isNumberValid = false;
                                        }
                                        break;
                                    case "Negative":
                                        if (input.val() >= 0) {
                                            input.next("span").html("please enter negative number");
                                            input.css("border-color", "red");
                                            isValid = false;
                                            isNumberValid = false;
                                        }
                                        break;
                                }
                            }
                        }
                        else {
                            input.next("span").html("please enter numbers");
                            input.css("border-color", "red");
                            isValid = false;
                            isNumberValid = false;
                        }

                        if (isNumberValid) {
                            input.next("span").html("");
                            input.css("border-color", "");
                        }
                    }
                }
                break;
            default:
                if (input.data("required")) {
                    var value = input.val().trim() || "";

                    if (value == "") {
                        var message = input.data("required") || "This Field is Required";
                        input.next("span").html(message.toLowerCase());
                        input.css("border-color", "red");
                        isValid = false;

                    }
                    else {
                        input.next("span").html("");
                        input.css("border-color", "");
                    }
                }
                break;
        }

    });

    isValidInputs = ValidateInputs(id);

    if (isValid == true && isValidInputs == true) {
        return isValid;
    }
    else {
        return false;
    }
}

function ValidateInputs(id) {
    var isValid = true;

    $("form#" + id + " :input").each(function () {
        var input = $(this);
        var data = input.data("value");
        var value = input.val().trim() || "";

        if (value == "") {
            return;
        }

        if (data) {

            switch (data) {
                case "numeric":
                    {
                        if (/^\d+$/.test(value) == false) {
                            var message = "please enter valid number";
                            input.next("span").html(message);
                            input.css("border-color", "red");
                            isValid = false;
                        }
                        else {
                            input.next("span").html("");
                            input.css("border-color", "");
                        }
                        break;
                    }
                case "character":
                    {
                        if (/^[a-zA-Z0-9- ]*$/.test(value) == false) {
                            var message = "This field accept characters only";
                            input.next("span").html(message);
                            input.css("border-color", "red");
                            isValid = false;
                        }
                        else {
                            input.next("span").html("");
                            input.css("border-color", "");
                        }
                        break;

                    }
                case "email":
                    {
                        var regex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                        if (!regex.test(value)) {
                            var message = "please enter valid email";
                            input.next("span").html(message);
                            input.css("border-color", "red");
                            isValid = false;
                        }
                        else {
                            input.next("span").html("");
                            input.css("border-color", "");
                        }
                        break;
                    }
            }
        }

    });
    return isValid;
}

function ClearForm(id) {
    var isValid = true;

    $("form#" + id + " :input").each(function () {
        var input = $(this);
        input.val("");
        input.next("span").html("");
        input.parent().parent().find("span.text-danger").html("");
        input.css("border-color", "");
    });
}

function isNumeric(event, value) {
    if ((event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105) && event.keyCode != 8 && event.keyCode != 9 && event.keyCode != 37 && event.keyCode != 39 && event.keyCode != 46) {
        event.preventDefault();
    }
}

function onImgError(image) {
    image.onerror = "";
    image.src = "/images/imgError.jpg";
    return true;
}

function AdjustContentTemplate(data) {
    if (data == null || data.length <= 0) {
        return "";
    }

    var tmp = data.substring(0, 30);
    tmp = data.length > 30 ? tmp + "..." : tmp;
    var html = "<p title='" + data + "' style='white-space: nowrap; overflow: hidden; text-overflow:ellipsis;'>" + tmp + "</p>";
    return html;
}

$(function () {
    $('textarea.no-comma').on('keydown', function (e) {
        if (e.keyCode == 188 || e.keyCode == 110) { // thats a comma
            e.preventDefault();
        }
    }).on('change input', function () {
        var self = $(this);
        self.html(self.html().replace(new RegExp(',', 'g'), '')); // Remove all commas.
    });
})