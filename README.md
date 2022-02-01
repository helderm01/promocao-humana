### Deploying a container to Heroku

```bash
# Build container `promocao-humana`
docker-compose build

# Heroku deploy process
heroku login
#heroku apps:create promocao-humana
heroku container:login
heroku container:push web -a promocao-humana
heroku container:release web -a promocao-humana
```