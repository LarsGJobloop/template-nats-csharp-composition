default:
  @just --list

# Starts the project
up:
  docker compose up --detach
  bento run ./mock/test-data.yaml

# Stops everything
down:
  docker compose down
