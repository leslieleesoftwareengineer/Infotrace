FROM node:12.18-alpine
ENV NODE_ENV=production
WORKDIR /usr/src/app
COPY ["infotrace/package.json", "./"]
RUN npm install 
COPY ./infotrace .
EXPOSE 3000
CMD ["npm", "start"]
