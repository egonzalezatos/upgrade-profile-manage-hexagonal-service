def namespace=      "profile-manage"
def appName=        "profile-manage-service"
def deploy=         "profile-manage-srv-depl"
def image=          "egonzalezatos/profile-manage:v2"
def environment=    "prod"
def k8s_path=       "./devops/Kubernetes/Service"

pipeline {

    agent any 
    stages {
        stage('Stage 1') {
            steps {
                echo 'Hello world!' 
            }
        }
    }
}

// node {
//     def namespace=      "profile-manage"
//     def appName=        "profile-manage-service"
//     def deploy=         "profile-manage-srv-depl"
//     def image=          "egonzalezatos/profile-manage:v2"
//     def environment=    "prod"
//     def k8s_path=       "./devops/Kubernetes/Service"
//     
//     stage('Docker Build') {
//         sh('docker build -t ${image} . -f ./devops/Docker/Dockerfile')
//     }
//     
//     stage('Docker Push') {
//         sh('docker push ${image}')
//     }
//     
//     stage('K8s Deployment') {
//         sh('kubectl get ns ${namespace} || kubectl create ns ${namespace}')   
//         sh('kubectl --namespace=${namespace} delete deploy ${deploy}') 
//         sh('kubectl --namespace=${namespace} apply -f kubectl apply -f ${k8s_path}/${profile-manage-srv-depl}.yml')   
//     }
// }