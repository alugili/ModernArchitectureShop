
# How to install to Kubernetes

## Prerequisites

1. Docker for Desktop with ready Kubernetes
2. Helm 3

## Getting Started

### Add repositories for Helm

```powershell
helm repo add bitnami https://charts.bitnami.com/bitnami
```

```powershell
helm repo add ingress-nginx https://kubernetes.github.io/ingress-nginx
```

```powershell
helm repo add stable https://kubernetes-charts.storage.googleapis.com/
```

```powershell
helm repo add carlosjgp https://carlosjgp.github.io/open-charts/
```

```powershell
helm repo add dapr https://daprio.azurecr.io/helm/v1/repo
```

```powershell
helm repo update
```

### Install Helm's charts

Open PowerShell at `D:\forks-netcore\tye\samples\dapr\helm\`

1. Install MS SqlServer

    ```powershell
    helm install sqlserver stable/mssql-linux --version 0.11.2 -f .\sqlserver.dev.yaml
    ```

1. Install Redis

    ```powershell
    helm install redis bitnami/redis -f .\redis.dev.yaml
    ```

1. Install NGINX Ingress Controller

    ```powershell
    helm install nginx ingress-nginx/ingress-nginx
    ```

1. Install Seq

    ```powershell
    helm install seq stable/seq --version 2.2.0 -f .\seq.dev.yaml
    ```

1. Install Zipkin

    ```powershell
    helm install zipkin carlosjgp/zipkin --version 0.2.0 -f .\zipkin.dev.yaml
    ```

### Install Dapr and its components

1. Install Dapr on Kubernetes

    ```powershell
    helm install dapr dapr/dapr
    ```

1. Install Dapr's components

    ```poweshell
    kubectl apply -f .\components
    ```

### Deploy our services via Tye

1. Tye deploy

    ```powershell
    tye deploy ..\tye-k8s.yaml --interactive
    ```

1. **Notes:** We'll be asked to input the following

    - Enter the connection string to use for service 'sqlserver': 
        > Data Source=sqlserver,1433;User Id=sa;Password=P@ssword;MultipleActiveResultSets=True

    - Enter the URI to use for service 'zipkin': 
        > http://zipkin-collector:9411/api/v2/spans

    -  Enter the URI to use for service 'seq': 
        > http://seq:5341

1. Deploy Ingress

    ```powershell
    kubectl apply -f .\k8s
    ```

1. Add hosts 

    ```text
    127.0.0.1	seq.mydomain.com
    127.0.0.1	ingestion.seq.mydomain.com

    127.0.0.1	zipkin.mydomain.com
    127.0.0.1	collector.zipkin.mydomain.com

    127.0.0.1	simplestore-graphql-api.local
    ```

## How to use

1. Open browser with the following addresses

    - Logging: `http://seq.mydomain.com`
    - Tracing: `http://zipkin.mydomain.com`
    - Store Application: `http://simplestore-graphql-api.local`

2. To access sqlserver

    - Forward port **1433**
        ```powershell
        kubectl port-forward service/sqlserver 1433:1433
        ```
    - Use the following information to access
        - Server Name: **127.0.0.1,1433**
        - Login: **sa**
        - Password: **P@ssword**

## Cleanup

```powershell
tye undeploy ..\tye-k8s.yaml

helm uninstall sqlserver redis seq zipkin nginx dapr

kubectl delete -f .\components

kubectl delete -f .\k8s
```