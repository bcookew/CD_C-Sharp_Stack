module.exports = function(grunt) {

grunt.initConfig({
    sass: {
        dist: {
            options: {
                loadPath: ['node_modules/foundation-sites/scss']
            },
            files: {
                'wwwroot/css/style.css' : 'wwwroot/css/style.scss'
            }
        }
    }
});

grunt.loadNpmTasks('grunt-contrib-sass');
grunt.registerTask('default', ['sass']);
};