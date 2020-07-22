
$(document).ready(function () {

    $("#CountryId").change(function () {
        $("#StateId").empty();
        $.ajax({
                cache: false,
                type: 'POST',
                url: 'GetStates',

                dataType: 'json',

                data: { id: $("#CountryId").val() },


                success: function (states) {


                    $.each(states, function (i, state) {
                        $("#StateId").append('<option value="' + state.Value + '">' +
                            state.Text + '</option>');

                    });
                },
                error: function (ex) {
                    alert('Failed to retrieve states.' + ex);
                }
            });
            return false;
        })
        });

$(document).ready(function () {

    $("#StateId").change(function () {
        $("#CityId").empty();
        $.ajax({
                cache: false,
                type: 'POST',
                url: 'GetCities',
                dataType: 'json',
                data: { id: $("#StateId").val() },

                success: function (cities) {

                    $.each(cities, function (i, city) {
                        $("#CityId").append('<option value="'
                            + city.Value + '">'
                            + city.Text + '</option>');
                    });
                },
                error: function (ex) {
                    alert('Failed.' + ex);
                }
            });
            return false;
        })
        });


