node {
    stage 'Building image'
    bat "docker build -t webapitemplate-build:${env.BUILD_TAG} -f Dockerfile.build ."
    
    def buildEnv = docker.image("webapitemplate-build:${env.BUILD_TAG}")
    myEnv.inside {
        //Something
    }
}