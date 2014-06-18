/// <reference path="c:\projects\git\singular\singular.web.admin.jstests\scripts\jasmine.js" />
/// <reference path="c:\projects\git\singular\singular.web.admin.jstests\dummyclass.js" />


describe("Test 1", function () {

    it("Returns 1", function() {
        expect(new HelloWorld().Init().toEqual(1));
    });

});
