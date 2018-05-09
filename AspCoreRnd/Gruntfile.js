module.exports = function (grunt) {
    grunt.initConfig({
        clean: ["temp/"],
        concat: {
            all: {
                src: ['TypeScript/Tastes.js', 'TypeScript/Food.js'],
                dest: 'temp/combined.js'
            }
        },
        jshint: {
            files: ['temp/*.js'],
            options: {
                '-W069': false,
            }
        }
    });
    
    grunt.loadNpmTasks("grunt-contrib-clean");
};
