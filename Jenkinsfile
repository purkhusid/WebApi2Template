#!groovy
node {
    stage 'Pulling from repo'
    git credentialsId: 'c429ab2d-0092-441b-8243-bad01323e1c5', url: 'https://github.com/sjuberman/WebApi2Template.git'

    stage 'Building image'
    bat "docker build -t webapitemplate-build:${env.BUILD_TAG} -f Dockerfile.build ."
    
    def buildEnv = docker.image("webapitemplate-build:${env.BUILD_TAG}")
    buildEnv.inside {
        stage 'Run Unit Tests'
        stage 'Run Integration Tests'
        stage 'Run Acceptance Tests'
    }
}