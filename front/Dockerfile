# Stage 1: Build the Angular application
FROM node:20 as build
WORKDIR /app

RUN npm install -g npm@10.4.0

COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build:prd

# Stage 2: Serve the app with Nginx
FROM nginx:alpine
COPY --from=build /app/dist/out/ /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
