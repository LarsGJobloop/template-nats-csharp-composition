default:
  @just --list

# Starts the project
up:
  docker compose up --detach
  bento run ./mock/test-data.yaml

# Stops everything
down:
  docker compose down

# Clears any generated resources (volumes, local images, networks, dangling containers)
clean:
  docker compose down --volumes --remove-orphans --rmi local
