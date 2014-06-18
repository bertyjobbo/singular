/// <reference path="scripts\jasmine.js" />
/// <reference path="dummyclass.js" />


describe("Test 1", function () {

    it("Returns 1", function () {
        var hw = new HelloWorld();
        var initVal = hw.Init();
        expect(initVal === 1);
        expect(5 === 5);
        expect(5 !== "5");
    });

});
