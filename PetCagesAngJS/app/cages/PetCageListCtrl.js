(function() {
    "use strict";

    angular.module("PetCages").controller("PetCageListCtrl", ["cageResource", PetCageListCtrl]);    



    function PetCageListCtrl(cageResource) {
        var list = this;

        cageResource.query(function(data) {
            list.cageList = data;                        
        });
    }

    //angular.module("PetCages2").controller("PetCageListCtrl", PetCageListCtrlFunc2);

    //function PetCageListCtrlFunc2() {

    //    var list = this;

    //    list.cages1to5 = [
    //        {
    //            "cageNo": 1,
    //            "cageAnimal": "",
    //            "cageCount": 0,
    //            "cageMax": 0,
    //            "predator": false,
    //            "nextToPredator": false
    //        },
    //        {
    //            "cageNo": 2,
    //            "cageAnimal": "Tarantula",
    //            "cageCount": 5,
    //            "cageMax": 10,
    //            "predator": false,
    //            "nextToPredator": true
    //        },
    //        {
    //            "cageNo": 3,
    //            "cageAnimal": "Big Cats",
    //            "cageCount": 1,
    //            "cageMax": 1,
    //            "predator": true,
    //            "nextToPredator": true
    //        },
    //        {
    //            "cageNo": 4,
    //            "cageAnimal": "Big Cats",
    //            "cageCount": 1,
    //            "cageMax": 1,
    //            "predator": true,
    //            "nextToPredator": true
    //        },
    //        {
    //            "cageNo": 5,
    //            "cageAnimal": "Big Cats",
    //            "cageCount": 1,
    //            "cageMax": 1,
    //            "predator": true,
    //            "nextToPredator": true
    //        }
    //    ];

    //    list.cages6 = [
    //        {
    //            "cageNo": 6,
    //            "cageAnimal": "Big Cats",
    //            "cageCount": 1,
    //            "cageMax": 1,
    //            "predator": true,
    //            "nextToPredator": true
    //        }
    //    ];

    //    list.cages7 = [
    //        {
    //            "cageNo": 7,
    //            "cageAnimal": "",
    //            "cageCount": 0,
    //            "cageMax": 0,
    //            "predator": false,
    //            "nextToPredator": true
    //        }
    //    ];


    //    list.cages12to8 = [
    //        {
    //            "cageNo": 12,
    //            "cageAnimal": "Rats",
    //            "cageCount": 5,
    //            "cageMax": 5,
    //            "predator": false,
    //            "nextToPredator": false
    //        },
    //        {
    //            "cageNo": 11,
    //            "cageAnimal": "Squirrels",
    //            "cageCount": 2,
    //            "cageMax": 3,
    //            "predator": false,
    //            "nextToPredator": false
    //        },
    //        {
    //            "cageNo": 10,
    //            "cageAnimal": "Squirrels",
    //            "cageCount": 3,
    //            "cageMax": 3,
    //            "predator": false,
    //            "nextToPredator": false
    //        },
    //        {
    //            "cageNo": 9,
    //            "cageAnimal": "Kangaroos",
    //            "cageCount": 1,
    //            "cageMax": 1,
    //            "predator": false,
    //            "nextToPredator": false
    //        },
    //        {
    //            "cageNo": 8,
    //            "cageAnimal": "Kangaroos",
    //            "cageCount": 1,
    //            "cageMax": 1,
    //            "predator": false,
    //            "nextToPredator": false
    //        }
    //    ];

    //    list.cages13 = [
    //        {
    //            "cageNo": 13,
    //            "cageAnimal": "Rats",
    //            "cageCount": 5,
    //            "cageMax": 5,
    //            "predator": false,
    //            "nextToPredator": false
    //        }
    //    ];

    //    list.cages14 = [
    //        {
    //            "cageNo": 14,
    //            "cageAnimal": "Rabbits",
    //            "cageCount": 2,
    //            "cageMax": 3,
    //            "predator": false,
    //            "nextToPredator": false
    //        }
    //    ];
    //}
}());
